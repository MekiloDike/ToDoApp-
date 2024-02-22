using Microsoft.AspNetCore.Identity;

namespace ToDoApp.Models
{
    public class User : IdentityUser
    {
        //public string Id { get; set; } = Guid.NewGuid().ToString(); //this is already in IdentityUser Class
        //public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        //public string? Password { get; set; } //no need adding this, it will automatically hash the password
        public int Age { get; set; }
        //public Address Address { get; set; } one to one mapping
    }
}
