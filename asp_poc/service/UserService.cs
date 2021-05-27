using asp_poc.Entity;
using asp_poc.Model;
using Microsoft.Extensions.Logging;

namespace asp_poc.service
{
    public class UserService
    {
        
        private readonly ILogger<UserService> _logger;
        private readonly CustomDbContext _customDbContext;

        public UserService(ILogger<UserService> logger, CustomDbContext customDbContext)
        {
            _logger = logger;
            _customDbContext = customDbContext;
        }

        public UserDto GetUser(string id)
        {
            return new UserDto(_customDbContext.Find<User>(id));
        }

        public UserDto DeleteUser(string id)
        {
            throw new System.NotImplementedException();
        }

        public UserDto EditUser(string id, UserDto user)
        {
            throw new System.NotImplementedException();
        }

        public UserDto AddUser(UserDto user)
        {
            User userEntity = new User(user);
            _customDbContext.Add(userEntity);
            _customDbContext.SaveChanges();
            user.Id = userEntity.Id;
            return user;
        }
    }
}