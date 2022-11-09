using AutoMapper;
using Billing.Organization.Business.Interface;
using Billing.Organization.Domains.Entities;
using Billing.Organization.Domains.Models;
using Billing.Organization.Infrastructure.Intefaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.Organization.Business.Services
{
    public class ServiceServiceAsync : IServiceServiceAsync
    {
        private readonly IServiceRepositoryAsync _serviceRepository;
        private readonly IMapper _mapper;
        private HttpResponse<ServiceDTO> _response;

        public ServiceServiceAsync(IServiceRepositoryAsync serviceRepository, IMapper mapper )
        {
            _serviceRepository = serviceRepository;
            _mapper = mapper;
            _response = new HttpResponse<ServiceDTO>();
        }
        public async Task<HttpResponse<ServiceDTO>> Create(ServiceDTO model)
        {
            var institution = _mapper.Map<Service>(model);
            await _serviceRepository.CreateAsync(institution);

            return _response;
        }

        public async Task<HttpResponse<ServiceDTO>> Delete(Guid Id)
        {
            await _serviceRepository.DeleteAsync(Id);
            return _response;
        }

        public async Task<HttpResponse<ServiceDTO>> GetAll()
        {
            var services = await _serviceRepository.GetAllAsync();
            var models = _mapper.Map<IEnumerable<ServiceDTO>>(services);

            _response.Result = models;
            return _response;
        }

        public async Task<HttpResponse<ServiceDTO>> GetById(Guid id)
        {
            var service = await _serviceRepository.GetOneAsync(id);
            var model = _mapper.Map<ServiceDTO>(service);

            _response.Result = new List<ServiceDTO> { model };
            return _response;   
        }

        public async Task<HttpResponse<ServiceDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            var services = await _serviceRepository.GetPageListAsync(pageNumber, pageSize);
            var models = _mapper.Map<IEnumerable<ServiceDTO>>(services);
            _response.Result = models;

            return _response;
        }

        public async Task<HttpResponse<ServiceDTO>> Update(ServiceDTO model)
        {
            var service = _mapper.Map<Service>(model);
            var updated = await _serviceRepository.UpdateAsync(service);
            _response.IsSuccess = updated;

            return _response;
        }
    }
}
