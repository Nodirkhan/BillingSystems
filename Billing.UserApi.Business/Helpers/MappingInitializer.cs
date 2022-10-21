using AutoMapper;
using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Domains.Models;

namespace Billing.UserApi.Business.Helpers
{
    public class MappingInitializer : Profile
    {
        public MappingInitializer()
        {
            /// UserMapping
            CreateMap<User, UserForCreationDTO>().ReverseMap();
            CreateMap<User, UserForModifiedDTO>().ReverseMap();
            CreateMap<User, UserForGetDTO>().ReverseMap();
        }
    }
}
