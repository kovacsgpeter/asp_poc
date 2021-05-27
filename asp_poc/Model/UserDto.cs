using System;
using asp_poc.Entity;

namespace asp_poc.Model
{
    public class UserDto


    {
        // TODO why only public works
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public DateTime CreatedDate { get; set; }

        public UserDto()
        {
        }

        public UserDto(User user)
    {
        this.Id = user.Id;
        this.Name = user.Name;
        this.Role = user.Role;
        this.CreatedDate = user.CreatedDate;
    }
    }
}