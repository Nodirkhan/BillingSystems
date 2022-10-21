using Billing.Authentication.Business.Services;
using Billing.Authentication.Domains.Entities;
using Billing.Authentication.Domains.Models;
using Billing.Authentication.Infrastructure.Interface;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Billing.Authentication.Business.Test
{
    public class AuthenticationTest
    {
        private Mock<IUserRepositoryAsync> _userRepository = new Mock<IUserRepositoryAsync>();
        private UserServiceAsync _userService;
        public AuthenticationTest() 
        {
            _userService = new UserServiceAsync(_userRepository.Object);
        }
        [Fact]
        public async Task LoginAsync_ShouldReturnIsSuccesTrue_WhenUserIsExist()
        {
            //Arrange

            var login = new Login
            {
                UserName = "key",
                Password = "key"
            };
            var user = new User
            {
                UserName = "Something",
                FirstName = "Something",
                LastName = "Something",
                Id = Guid.NewGuid().ToString(),
                Password = "Something",
            };
            _userRepository.Setup(x =>
                x.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                  .ReturnsAsync(user);

            //Act

            var response = await _userService.LoginAsync(login);

            // Assert
            _userRepository.Verify(x => x.LoginAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Result);
        }

        [Fact]
        public async Task LoginAsync_ShouldReturnFalse_WhenUserDoesNotExist()
        {
            //Arrange
            var login = new Login
            {
                UserName = "key",
                Password = "key"
            };

            _userRepository.Setup(x => x.LoginAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(() => null);

            //Act
            var response = await _userService.LoginAsync(login);

            //Assert
            _userRepository.Verify(x => x.LoginAsync(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.False(response.IsSuccess);
            Assert.Null(response.Result);
        }
    }

}
