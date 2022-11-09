using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Domains.Models;
using Moq;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Billing.UserApi.Business.Test.UserTest
{
    public class GetOneAsyncTest : UserServiceAsyncTest
    {
        [Fact]
        public async Task GetOneAsync_ShouldReturnIsSuccessFalse_WhenUserDoesNotExist()
        {
            //Arrange
            _userRepoMock.Setup(x => x.FindbyCondition(It.IsAny<Expression<Func<User, bool>>>()))
                .ReturnsAsync(() => null);

            //Act
            var response = await _userService.GetOneAsync(Guid.NewGuid().ToString());

            //Assert
            Assert.False(response.IsSuccess);
            Assert.Null(response.Result);
            Assert.Equal(404, response.StatusCode);
            _userRepoMock.Verify(x => x.FindbyCondition(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
            _mapperMock.Verify(x => x.Map<UserForGetDTO>(It.IsAny<User>()), Times.Never);

        }

        [Fact]
        public async Task GetOneAsync_ShouldReturnCostumer_WhenCustomerExist()
        {
            //Arrange
            var Id = Guid.NewGuid().ToString();

            _userRepoMock
                 .Setup(x => x.FindbyCondition(It.IsAny<Expression<Func<User, bool>>>()))
                 .ReturnsAsync(new User());

            // Act 
            var response = await _userService.GetOneAsync(Id);

            //Assert
            _userRepoMock.Verify(x => x.FindbyCondition(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
            _mapperMock.Verify(x => x.Map<UserForGetDTO>(It.IsAny<User>()), Times.Never);
            Assert.True(response.IsSuccess);
            Assert.Single(response.Result);
            Assert.NotNull(response.Result);
            Assert.Equal(200, response.StatusCode);
        }
    }
}
