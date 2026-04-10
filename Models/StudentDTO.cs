namespace StudentManagementSystem.Models
{
    public class StudentDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int Age { get; set; }
        public required string Course { get; set; }
    }
}
