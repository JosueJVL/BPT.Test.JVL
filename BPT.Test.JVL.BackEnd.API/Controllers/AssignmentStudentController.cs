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
    public class AssignmentStudentController : ControllerBase
    {
        private readonly IAssignmentStudentService service;

        public AssignmentStudentController(IAssignmentStudentService service)
        {
            this.service = service;
        }

        // GET: api/AssignmentStudent
        [HttpGet]
        public async Task<IEnumerable<AssignmentStudentDto>> Get()
        {
            return await service.GetAll();
        }

        // GET: api/AssignmentStudent/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<AssignmentStudentDto>> GetById(int id)
        {
            return await service.GetById(id);
        }

        // POST: api/AssignmentStudent
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentStudentDto value)
        {
            var result = await service.Create(value);
            return CreatedAtAction("Get", new { id = result.IdStudent }, result);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (await service.Remove(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
