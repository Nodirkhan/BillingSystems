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
            var user = new User
            {
                UserName = "Something",
                FirstName = "Something",
                LastName = "Something",
                Id = Guid.NewGuid().ToString(),
                Password = "Something",
            };
            var user1 = new UserForGetDTO
            {
                UserName = "Something",
                FirstName = "Something",
                LastName = "Something",
                Id = Guid.NewGuid().ToString(),
                Password = "Something",
            };
            var list = new List<User> { user};
            var list1 = new List<UserForGetDTO> { user1};
            _userRepoMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(list);
            _mapperMock.Setup(x => x.Map<IEnumerable<UserForGetDTO>>(list))
                .Returns(list1);
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
            var single = Assert.Single(response.Result);
            Assert.Equal(user.FirstName, single.FirstName);
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
