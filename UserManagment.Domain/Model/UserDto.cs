namespace UserManagment.API.Model
{
    public class UserDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }

        public AddressDto Address { get; set; }
    }
}
