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
    public class UserServiceTest
    {
        private CustomDbContext _context;
        // private ILogger<UserService> _logger;
      


        // public UserServiceTest(UserService userService) => _userService = userService;
        
        // TODO: https://stackoverflow.com/questions/66879177/abstract-generic-mocking-cannot-instantiate-proxy-class-of-property
        // TODO: https://stackoverflow.com/questions/63801893/system-notsupportedexception-unsupported-expression-x-x
        private void SetupMocks() 
        {
            // 1. Create moq object
            var config = new Mock<IConfiguration>();
            var context = new Mock<CustomDbContext>(null);
            var logger = new Mock<ILogger>();
            var users = new Mock<DbSet<User>>();

            
            // 2. Setup the returnables
            context
                .SetupGet(o => o._users
                    // .Find(It.IsAny<string>()))
                ).Returns(users.Object);
            // input.SetupGet(x => x.ColumnNames).Returns(temp);


            //     
                //     // 2. Setup the returnables
                users
                .Setup(o => o.Find(It.IsAny<string>()))
                    //.Find(It.IsAny<string>()))
                .Returns(
                    new User(
                    "1001",
                    "Mr.A",
                    new Role("Admin")
                    )
                );

            // 3. Assign to Object when needed
            _context = context.Object;
        }

        [Fact]
        public void Test1()
        {
            SetupMocks();
            
            UserService userService = new UserService(null, _context);
            UserDto userDto = userService.GetUser("any");
            Assert.True(userDto.Id.Equals("1001"));
            Assert.True(userDto.Name.Equals("Mr.A"));
            Assert.True(userDto.Role.Equals("Admin"));
            Assert.NotNull(userDto.CreatedDate);



        }
        [Fact]
        public void Test2()
        {
            SetupMocks();
            
            UserService userService = new UserService(null, _context);
            UserDto userDto = userService.DeleteUser("any");
            Assert.True(userDto.Id.Equals("1001"));
            Assert.True(userDto.Name.Equals("Mr.A"));
            Assert.True(userDto.Role.Equals("Admin"));
            Assert.NotNull(userDto.CreatedDate);



        }
        
       
    }
}