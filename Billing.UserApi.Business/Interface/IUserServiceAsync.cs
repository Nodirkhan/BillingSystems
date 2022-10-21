using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Domains.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.UserApi.Business.Interface
{
    public interface IUserServiceAsync
    {
        Task<HttpResponse<UserForGetDTO>> GetAllAsync();
        Task<HttpResponse<UserForGetDTO>> GetPageListAsync(int pageNumber, int pageSize);
        Task<HttpResponse<UserForGetDTO>> GetOneAsync(string id);
        Task<HttpResponse<UserDTO>> CreateAsync(UserForCreationDTO userDTO);
        Task<HttpResponse<UserDTO>> Update(UserForModifiedDTO userDTO);
        Task<HttpResponse<UserDTO>> DeleteAsync(string id);
        Task<HttpResponse<UserDTO>> UpdatePasswordAsync(string id, string password);
    }
}
