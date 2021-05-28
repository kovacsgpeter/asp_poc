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

            User userEntity = _customDbContext.Find<User>(id);
            _customDbContext.Remove<User>(userEntity);
            _customDbContext.SaveChanges();
            return new UserDto(userEntity);
        }

        public UserDto EditUser(string id, UserDto user)
        {
            User userEntity = _customDbContext.Find<User>(id);
            ExchangeData(userEntity, user);
            _customDbContext.Users.Update(userEntity);
            _customDbContext.SaveChanges();
            return user;
        }

        private void ExchangeData(User userOld, UserDto userNew)
        {
            if (userNew.Name != null) userOld.Name = userNew.Name;
            if (userNew.Role != null) userOld.Role = userNew.Role;
            userNew.Id = userOld.Id;
            userNew.CreatedDate = userOld.CreatedDate;
            
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