using asp_poc.Controllers;
using asp_poc.Entity;
using asp_poc.Model;
using asp_poc.service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace asp_poc_test
{
    public class UserControllerTest
    {
        private UserService _userService;
        // private ILogger<UserService> _logger;
      


        // public UserServiceTest(UserService userService) => _userService = userService;
        
        // TODO: https://stackoverflow.com/questions/66879177/abstract-generic-mocking-cannot-instantiate-proxy-class-of-property
        // TODO: https://stackoverflow.com/questions/63801893/system-notsupportedexception-unsupported-expression-x-x
        private UserController SetupMocks() 
        {
            // 1. Create moq object
            var userService = new Mock<UserService>(null, null);
            var userDto = new UserDto();
            userDto.Name = "Mr.A";
            userDto.Role = new Role("Admin").Name;
            userDto.Id = "1001";

            
            // 2. Setup the returnables
            userService
                .Setup(o => o.DeleteUser(It.IsAny<string>())
                    // .Find(It.IsAny<string>()))
                ).Returns(userDto).Verifiable();
            // input.SetupGet(x => x.ColumnNames).Returns(temp);



                     // 2. Setup the returnablesű
            var mock = new Mock<ILogger<UserController>>();
            ILogger<UserController> logger = mock.Object;
            // mock
            //     .Setup(o => o.LogInformation(It.IsAny<ILogger>(), It.IsAny<string>(), It.IsAny<object[]>())
            //         // .Find(It.IsAny<string>()))
            //     ).Verifiable();
            _userService = userService.Object;

            return new UserController(logger, _userService);
        }

        [Fact]
        public void Test1()
        {
           
            UserController userController = SetupMocks();
            UserDto userDto = userController.Delete("any");
            Assert.True(userDto.Id.Equals("1001"));
            Assert.True(userDto.Name.Equals("Mr.A"));
            Assert.True(userDto.Role.Equals("Admin"));
            Assert.NotNull(userDto.CreatedDate);



        }
       
        
       
    }
}