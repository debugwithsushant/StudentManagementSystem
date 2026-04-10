using StudentManagementSystem.Models;

namespace StudentManagementSystem.Services
{
    public interface IStudentService
    {
        // Get all students
        Task<List<Student>> GetAllStudentsAsync();

        // Get student by Id
        Task<Student?> GetStudentByIdAsync(int id);

        // Add new student
        Task<Student> AddStudentAsync(StudentDTO studentDTO);

        // Update existing student
        Task<Student?> UpdateStudentAsync(int id, StudentDTO studentDTO);

        // Delete student by Id
        Task<bool> DeleteStudentAsync(int id);
    }
}
