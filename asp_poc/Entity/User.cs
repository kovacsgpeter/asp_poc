using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using asp_poc.Model;

namespace asp_poc.Entity
{
    public class User
    {
        public User()
        {
        } 
        
        public User(string id, string name, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;
        }

        public User(UserDto user)
        {
            this.Name = user.Name;
            this.Role = user.Role;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        // TODO fill createddate enity framework core
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
}