using AutoMapper;
using Billing.UserApi.Business.Services;
using Billing.UserApi.Domains.Entities;
using Billing.UserApi.Domains.Models;
using Billing.UserApi.Infrstructure.Interface;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xunit;

namespace Billing.UserApi.Business.Test.UserTest
{
    public class UserServiceAsyncTest
    {
        protected Mock<IUserRepositoryAsync> _userRepoMock;
        protected Mock<IMapper> _mapperMock = new Mock<IMapper>();
        protected UserServiceAsync _userService;
        public UserServiceAsyncTest()
        {
            _userRepoMock = new Mock<IUserRepositoryAsync>();
            _userService = new UserServiceAsync(_userRepoMock.Object, _mapperMock.Object);
        }
    }

    
}
