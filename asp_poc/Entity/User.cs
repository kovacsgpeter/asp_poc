using System;
using System.Collections;
using System.Collections.Generic;
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
        
        public User(string id, string name, Role role)
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;
        }

        public User(UserDto user)
        {
            this.Name = user.Name;
            // this.Role = user.Role;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }
        public Role Role { get; set; }
        // TODO fill createddate enity framework core
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
    }
    
}