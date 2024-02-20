using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Models
{
    public class AppUser
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Gender { get; set; }
        public int Age { get; set; }
        public List<ToDo>? UsersTodo { get; set; }//foreign key
    }
}
