using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace asp_poc.Entity
{
    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }
        public string Other { get; set; }
        public ICollection<UserAddress> UserAddresses { get; set; }

    }
}