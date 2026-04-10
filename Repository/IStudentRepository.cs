using StudentManagementSystem.Models;

namespace StudentManagementSystem.Repository
{
    public interface IStudentRepository
    {
        // Get all students from database
        Task<List<Student>> GetAllAsync();


        // Get student by Id
        Task<Student?> GetByIdAsync(int id);

        // Add new student
        Task<Student> AddAsync(StudentDTO studentDTO);

        // Update existing student
        Task<Student?> UpdateAsync(int id, StudentDTO studentDTO);

        // Delete student by Id
        Task<bool> DeleteAsync(int id);
    }
}
