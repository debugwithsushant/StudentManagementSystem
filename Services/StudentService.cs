using StudentManagementSystem.Models;
using StudentManagementSystem.Repository;

namespace StudentManagementSystem.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        // Inject Repository
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        // Call repository to get all students
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        // Get student by Id
        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        // Add new student
        public async Task<Student> AddStudentAsync(StudentDTO studentDTO)
        {
            return await _repository.AddAsync(studentDTO);
        }

        // Update existing student
        public async Task<Student?> UpdateStudentAsync(int id, StudentDTO studentDTO)
        {
            return await _repository.UpdateAsync(id, studentDTO);
        }

        // Delete student by Id
        public async Task<bool> DeleteStudentAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
