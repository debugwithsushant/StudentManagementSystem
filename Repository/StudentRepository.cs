using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        // Inject DbContext
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Fetch all students from DB
        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students.ToListAsync();
        }

        // Get student by Id
        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        // Add new student
        public async Task<Student> AddAsync(StudentDTO studentDTO)
        {
            // Map DTO to Student entity
            var student = new Student()
            {
                Name = studentDTO.Name,
                Email = studentDTO.Email,
                Age = studentDTO.Age,
                Course = studentDTO.Course,
                CreatedDate = DateTime.Now
            };

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        // Update existing student
        public async Task<Student?> UpdateAsync(int id, StudentDTO studentDTO)
        {
            // Find student by Id
            var student = await _context.Students.FindAsync(id);

            // If not found return null
            if (student == null) return null;

            // Update fields
            student.Name = studentDTO.Name;
            student.Email = studentDTO.Email;
            student.Age = studentDTO.Age;
            student.Course = studentDTO.Course;

            await _context.SaveChangesAsync();
            return student;
        }

        // Delete student by Id
        public async Task<bool> DeleteAsync(int id)
        {
            // Find student by Id
            var student = await _context.Students.FindAsync(id);

            // If not found return false
            if (student == null) return false;

            // Remove student from DB
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
