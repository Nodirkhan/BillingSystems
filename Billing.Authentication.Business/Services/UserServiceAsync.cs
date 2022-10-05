using Billing.Authentication.Business.Interface;
using Billing.Authentication.Domains.Entities;
using Billing.Authentication.Domains.Models;
using Billing.Authentication.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Billing.Authentication.Business.Services
{
    public class UserServiceAsync : IUserServiceAsync
    {
        HttpResponse response;
        private IUserRepositoryAsync _userRepository;

        public UserServiceAsync(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
            response = new HttpResponse();
        }

        public async Task<HttpResponse> CreateAsync(User user)
        {
            try
            {
                await _userRepository.CreateAsync(user);
                return response;
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.StatusMessage = ex.Message;
                response.StatusCode = ex.HResult;
                return response;
            }
        }

        #region Login  Method

        public async Task<HttpResponse> LoginAsync(Login login)
        {
            var user = await _userRepository.LoginAsync(login.UserName, login.Password);
            if(user is not null)
            {
                var claims = GenerateClaims(user);
                string token = GetToken(claims);
                response.Result = new List<string> { token};
                return response;
            }
            response.StatusCode = 404;
            return response;
        }
        private List<Claim> GenerateClaims(User user)
        {
            return new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Role, "client")
            };
        }
        private string GetToken(List<Claim> claims)
        {
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1)
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
        #endregion
    }
}
