using System;
using System.Collections.Generic;
using asp_poc.Entity;
using asp_poc.Model;
using asp_poc.service;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace asp_poc_test
{
    public class UserServiceTest
    {
        private CustomDbContext _context;
        private ILogger<UserService> _logger;
      


        // public UserServiceTest(UserService userService) => _userService = userService;
        
        // TODO: https://stackoverflow.com/questions/66879177/abstract-generic-mocking-cannot-instantiate-proxy-class-of-property
        // TODO: https://stackoverflow.com/questions/63801893/system-notsupportedexception-unsupported-expression-x-x
        private void SetupMocks() 
        {
            // 1. Create moq object
            var context = new Mock<CustomDbContext>();
            var logger = new Mock<ILogger>();
            var dbSet = new Mock<DbSet<User>>();

            
            // 2. Setup the returnables
            context
                .Setup(o => o.getUsers()
                    //.Find(It.IsAny<string>()))
                ).Returns(dbSet.Object);  
                    
                    // 2. Setup the returnables
                    dbSet
                .Setup(o => o.Find(It.IsAny<string>())
                    //.Find(It.IsAny<string>()))
                ).Returns(
                    new User(
                    "1001",
                    "Mr.A",
                    "A"
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


        }
    }
}