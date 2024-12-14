using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentAppWebAPI.Data;
using StudentAppWebAPI.Models.Entities;

namespace StudentAppWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly ApplicationDbContext _context; 
        public StudentController(ApplicationDbContext context) 
        { 
            _context = context; 
        }

        //GET: api/Student
        [HttpGet]
         public ActionResult<IEnumerable<Student>> GetStudents() 
        { 
            return _context.Student.ToList(); 
        }

       // GET: api/Student/1 
        [HttpGet("{id}")]
        public ActionResult<Student> GetStudent(int id)
        {
            var student = _context.Student.Find(id); 
            if (student == null) 
            { return NotFound(); 
            }
            return student;
        }

       // POST: api/Student
        [HttpPost]
         public ActionResult<Student> PostStudent(Student student)
        {
            _context.Student.Add(student);
            _context.SaveChanges(); 
            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }
        //PUT: api/Student/1 
        [HttpPut("{id}")]
        public IActionResult PutStudent(int id, Student student)
        {
            if (id != student.Id) 
            { 
                return BadRequest(); 
            }
            _context.Entry(student).State = EntityState.Modified;
            _context.SaveChanges(); 
            return NoContent();
        } 

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Student.Find(id);
            if (student == null) 
            { 
                return NotFound(); 
            }
            _context.Student.Remove(student); 
            _context.SaveChanges();
            return NoContent();
        }
    }
}
