using Microsoft.AspNetCore.Mvc;
using PostgreSQL.Data;

namespace csBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeacherController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public TeacherController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetTeachers()
        {
            var teachers = _dbContext.Teachers.ToList();
            return Ok(teachers);
        }

        [HttpGet("{id}")]
        public IActionResult GetTeacherById(int id)
        {
            var teacher = _dbContext.Teachers.FirstOrDefault(t => t.TeacherId == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return Ok(teacher); 
        }

        [HttpGet("lastname/{lastName}")]
        public IActionResult GetTeachersByLastName(string lastName)
        {
            var teachers = _dbContext.Teachers.Where(t => t.LastName == lastName).ToList();
            return Ok(teachers);
        }
    }
}
