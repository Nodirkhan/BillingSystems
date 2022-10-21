using AutoMapper;
using Billing.UserApi.Business.Interface;
using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Domains.Models;
using Billing.UserApi.Infrstructure.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Billing.UserApi.Business.Services
{
    public class UserServiceAsync : IUserServiceAsync
    {
        private readonly IUserRepositoryAsync _userRepository;
        private readonly IMapper _mapper;

        public UserServiceAsync(IUserRepositoryAsync userRepositoryAsync, IMapper mapper)
        {
            _userRepository = userRepositoryAsync;
            _mapper = mapper;
        }
        public async Task<HttpResponse<UserDTO>> CreateAsync(UserForCreationDTO userDTO)
        {
            HttpResponse<UserDTO> response = new();
            var isExist = await _userRepository.IsExist(userDTO.UserName);
            if (!isExist)
            {
                var user = _mapper.Map<User>(userDTO);
                await _userRepository.InsertAsync(user);
            }
            else
            {
                response.StatusMessage = "Username already exist";
                response.IsSuccess = false;
                response.StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status400BadRequest;
            }

            return response;
        }

        public async Task<HttpResponse<UserDTO>> DeleteAsync(string id)
        {
            HttpResponse<UserDTO> response = new();
            await _userRepository.DeleteAsync(id);
            return response;
        }

        public async Task<HttpResponse<UserForGetDTO>> GetAllAsync()
        {
            HttpResponse<UserForGetDTO> response = new();
            var users = await _userRepository.GetAllAsync();
            var toUserDtos = _mapper.Map<IEnumerable<UserForGetDTO>>(users);
            response.Result = toUserDtos;

            return response;
        }

        public async Task<HttpResponse<UserForGetDTO>> GetOneAsync(string id)
        {
            HttpResponse<UserForGetDTO> response = new();
            var user = await _userRepository.FindbyCondition(u => u.Id == id);
            if (user == null)
            {
                response.StatusCode = Microsoft.AspNetCore.Http
                    .StatusCodes.Status404NotFound;

                response.IsSuccess = false;
                return response;
            }

            var userDto = _mapper.Map<UserForGetDTO>(user);
            response.Result = new List<UserForGetDTO> { userDto };

            return response;
        }

        public async Task<HttpResponse<UserForGetDTO>> GetPageListAsync(int pageNumber, int pageSize)
        {
            HttpResponse<UserForGetDTO> response = new();
            var userDetails = await _userRepository.GetPageListAsync(pageNumber, pageSize);
            var toUserDtos = _mapper.Map<IEnumerable<UserForGetDTO>>(userDetails.users);
            response.Result = toUserDtos;
            response.TotalCount = (int)userDetails.totalCount;

            return response;
        }

        public async Task<HttpResponse<UserDTO>> Update(UserForModifiedDTO userDTO)
        {
            HttpResponse<UserDTO> response = new();
            var ExistUser = await _userRepository
                .FindbyCondition(u => u.UserName == userDTO.UserName);

            if (ExistUser == null || ExistUser.Id == userDTO.Id)
            {
                var user = _mapper.Map<User>(userDTO);

                await _userRepository.UpdateAsync(user);
            }
            else
            {
                response.IsSuccess = false;
                response.StatusMessage = "Username is already exist";
                response.StatusCode = Microsoft.AspNetCore.Http
                    .StatusCodes.Status400BadRequest;
            }

            return response;
        }
        /// <summary>
        /// Not Implemented
        /// </summary>
        /// <param name="id"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Task<HttpResponse<UserDTO>> UpdatePasswordAsync(string id, string password)
        {
            throw new System.NotImplementedException();
        }
    }
}
