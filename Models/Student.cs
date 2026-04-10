using System.ComponentModel.DataAnnotations;

namespace StudentManagementSystem.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required...!")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required...!")]
        [EmailAddress(ErrorMessage = "Invalid email format...!")]
        public required string Email { get; set; }

        [Range(1, 100, ErrorMessage = "Age must be between 1 and 100...!")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Course is required...!")]
        public string? Course { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
