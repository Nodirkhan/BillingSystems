using AutoMapper;
using Billing.Organization.Business.Interface;
using Billing.Organization.Domains.Models;
using Billing.Organization.Infrastructure.Intefaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Organization.Business.Services
{
    public class OrganizationServiceAsync : IOrganizationServiceAsync
    {
        private readonly IOrganizationRepositoryAsync _organizationReposiory;
        private readonly IMapper _mapper;
        private HttpResponse<OrganizationDTO> _response;

        public OrganizationServiceAsync(IOrganizationRepositoryAsync organizationRepository, IMapper mapper)
        {
            _organizationReposiory = organizationRepository;
            _mapper = mapper;
            _response = new HttpResponse<OrganizationDTO>();
        }
        public async Task<HttpResponse<OrganizationDTO>> Create(OrganizationDTO model)
        {
            var organization = _mapper.Map<Domains.Entities.Organization>(model);
            await _organizationReposiory.CreateAsync(organization);
            return _response;
        }

        public async Task<HttpResponse<OrganizationDTO>> Delete(Guid Id)
        {
            await _organizationReposiory.DeleteAsync(Id);
            return _response;
        }

        public async Task<HttpResponse<OrganizationDTO>> GetAll()
        {
            var organizations = await _organizationReposiory.GetAllAsync();
            var models = _mapper.Map<IEnumerable<OrganizationDTO>>(organizations);

            _response.Result = models;
            return _response;
        }

        public async Task<HttpResponse<OrganizationDTO>> GetById(Guid id)
        {
            var organization = await _organizationReposiory.GetOneAsync(id);
            var model = _mapper.Map<OrganizationDTO>(organization);

            _response.Result = new List<OrganizationDTO> { model };
            return _response;
        }

        public async Task<HttpResponse<OrganizationDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var organizations = await _organizationReposiory.GetPageListAsync(pageNumber, pageSize);
            var models = _mapper.Map<IEnumerable<OrganizationDTO>>(organizations);
            _response.Result = models;

            return _response;

        }

        public async Task<HttpResponse<OrganizationDTO>> Update(OrganizationDTO model)
        {
            var organization = _mapper.Map<Domains.Entities.Organization>(model);
            var updated = await _organizationReposiory.UpdateAsync(organization);
            _response.IsSuccess = updated;

            return _response;
        }
    }
}
