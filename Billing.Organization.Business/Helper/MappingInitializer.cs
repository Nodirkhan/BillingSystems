using AutoMapper;
using Billing.Organization.Domains.Entities;
using Billing.Organization.Domains.Models;

namespace Billing.Organization.Business.Helper
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            CreateMap<Domains.Entities.Organization, ServiceDTO>().ReverseMap();

            CreateMap<Institution, InstitutionForCreateDTO>().ReverseMap();
            CreateMap<Institution, InstitutionForUpdateDTO>().ReverseMap();
            CreateMap<Institution, InstitutionForGetDTO>().ReverseMap();

            CreateMap<Service, ServiceForGetDTO>().ReverseMap();
            CreateMap<Service, ServiceForCreateDTO>().ReverseMap();
            CreateMap<Service, ServiceForUpdateDTO>().ReverseMap();
        }
    }
}
