using ApiProject.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private MyDbContext db;
        public StudentController(MyDbContext _db)
        {
            db = _db;
        }



        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await db.Students.ToListAsync();
            return Ok(data);
        }



        [HttpGet("id")]
        public async Task<ActionResult<Student>> DetailStudent(int id)
        {
            var user = await db.Students.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }



        [HttpDelete("id")]
        public async Task<ActionResult<Student>> DeleteStd(int id)
        {
            var del = await db.Students.FindAsync(id);
            if (del == null)
            {
                return NotFound();
            }
            db.Students.Remove(del);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult<Student>> CreateStd(Student std)
        {
            await db.Students.AddAsync(std);
            await db.SaveChangesAsync();
            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> EditStd(int id, Student std)
        {
            if(id != std.Id)
            {
                return BadRequest();
            }
            db.Entry(std).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return Ok(std);
        }
    }
}
