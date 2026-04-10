using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentManagementSystem.Models;
using StudentManagementSystem.Services;

namespace StudentManagementSystem.Controllers
{
    // localhost:xxxx/api/employees
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;
        private readonly ILogger<StudentsController> _logger;

        // Inject Service and Logger
        public StudentsController(IStudentService service, ILogger<StudentsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        // GET: api/students
        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _service.GetAllStudentsAsync();
            return Ok(students);
        }

        // GET: api/students/{id}
        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _service.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound($"Student with ID {id} not found...!");
            return Ok(student);
        }

        // POST: api/students
        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] StudentDTO studentDTO)
        {
            // Validate incoming data
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _service.AddStudentAsync(studentDTO);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }


        // PUT: api/students/{id}
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] StudentDTO studentDTO)
        {
            // Validate incoming data
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var student = await _service.UpdateStudentAsync(id, studentDTO);
            if (student == null)
                return NotFound($"Student with ID {id} not found...!");
            return Ok(student);
        }

        // DELETE: api/students/{id}
        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _service.DeleteStudentAsync(id);
            if (!deleted)
                return NotFound($"Student with ID {id} not found...!");
            return Ok($"Student with ID {id} deleted successfully...!");
        }
    }
}
