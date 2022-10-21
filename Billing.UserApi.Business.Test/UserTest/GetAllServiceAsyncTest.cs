using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Domains.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Billing.UserApi.Business.Test.UserTest
{
    public class GetAllServiceAsyncTest : UserServiceAsyncTest
    {
        [Fact]
        public async Task Should_Return_NotEmpty_List_WhenUsersExist()
        {
            //Arrange

            _userRepoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(new List<User>());
            _mapperMock.Setup(x => x.Map<IEnumerable<UserForGetDTO>>(It.IsAny<List<User>>()))
                .Returns(new List<UserForGetDTO> { new UserForGetDTO(), new UserForGetDTO() });
            //Act
            var response = await _userService.GetAllAsync();

            //Assert
            _userRepoMock
                .Verify(x => x.GetAllAsync(), Times.Once);

            _mapperMock
                .Verify(x => x.Map<IEnumerable<UserForGetDTO>>(It.IsAny<IEnumerable<User>>()), Times.Once);

            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Result);
            Assert.NotEmpty(response.Result);
            var result = Assert.IsType<List<UserForGetDTO>>(response.Result);
            Assert.Equal(2, result.Count);
        }
        [Fact]
        public async Task Should_Return_NotEmpty_List_WhenUsersDontExist()
        {
            //Arrange
            _userRepoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(() => null);

            //Act
            var response = await _userService.GetAllAsync();

            //Assert
            _userRepoMock.Verify(x => x.GetAllAsync(), Times.Once);
            Assert.True(response.IsSuccess);
            Assert.NotNull(response.Result);
            Assert.Empty(response.Result);
        }
    }
}
