using AutoMapper;
using Billing.Organization.Business.Interface;
using Billing.Organization.Domains.Entities;
using Billing.Organization.Domains.Models;
using Billing.Organization.Infrastructure.Intefaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Organization.Business.Services
{
    internal class InstittutionServiceAsync : IInstitutionServiceAsync
    {
        private readonly IInstitutionRepositoryAsync _institutionRepo;
        private readonly IMapper _mapper;
        private HttpResponse<InstitutionDTO> _response;

        public InstittutionServiceAsync(IInstitutionRepositoryAsync institutionRepository, IMapper mapper)
        {
            _institutionRepo = institutionRepository;
            _mapper = mapper;
            _response = new HttpResponse<InstitutionDTO>();
        }
        public async Task<HttpResponse<InstitutionDTO>> Create(InstitutionDTO model)
        {
            var institution = _mapper.Map<Institution>(model);
            await _institutionRepo.CreateAsync(institution);
            return _response;
        }

        public async Task<HttpResponse<InstitutionDTO>> Delete(Guid Id)
        {
            await _institutionRepo.DeleteAsync(Id);
            return _response;   
        }

        public async Task<HttpResponse<InstitutionDTO>> GetAll()
        {
            var institutoin = await _institutionRepo.GetAllAsync();
            var models = _mapper.Map<IEnumerable<InstitutionDTO>>(institutoin);

            _response.Result = models;
            return _response;       
        }

        public async Task<HttpResponse<InstitutionDTO>> GetById(Guid id)
        {
            var institution = await _institutionRepo.GetOneAsync(id);
            var model = _mapper.Map<InstitutionDTO>(institution);

            _response.Result = new List<InstitutionDTO> { model };
            return _response;
        }

        public async Task<HttpResponse<InstitutionDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var instituions = await _institutionRepo.GetPageListAsync(pageNumber, pageSize);
            var models = _mapper.Map<IEnumerable<InstitutionDTO>>(instituions);
            _response.Result = models;

            return _response;
        }

        public async Task<HttpResponse<InstitutionDTO>> Update(InstitutionDTO model)
        {
            var institution = _mapper.Map<Institution>(model);
            var updated = await _institutionRepo.UpdateAsync(institution);

            _response.IsSuccess = updated;
            _response.StatusCode = StatusCodes.Status400BadRequest;

            return _response;
        }
    }
}
