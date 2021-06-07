using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_poc.Entity
{
    public class Role
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }

}