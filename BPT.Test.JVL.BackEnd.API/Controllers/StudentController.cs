using System.Collections.Generic;
using System.Threading.Tasks;
using BPT.Test.JVL.BackEnd.Services.DTOs;
using BPT.Test.JVL.BackEnd.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BPT.Test.JVL.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IEnumerable<StudentsDto>> Get()
        {
            return await studentService.GetStudents();
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentsDto>> Get(int id)
        {
            return await studentService.GetStudentById(id);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] StudentsDto value)
        {
            var result = await studentService.Create(value);
            return CreatedAtAction("Get", new { id = result.IdStudent }, result);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] StudentsDto value)
        {
            if (await studentService.Update(id, value))
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await studentService.Remove(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
