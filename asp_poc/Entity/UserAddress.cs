namespace asp_poc.Entity
{
    public class UserAddress
    {
        public string AddressId { get; set; }
        public string UserId { get; set; }
        public Address Address { get; set; }
        public User User { get; set; }

    }
}