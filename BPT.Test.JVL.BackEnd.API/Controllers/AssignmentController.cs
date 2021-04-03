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
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService service;

        public AssignmentController(IAssignmentService service)
        {
            this.service = service;
        }

        // GET: api/Assignment
        [HttpGet]
        public async Task<IEnumerable<AssignmentDto>> Get()
        {
            return await service.GetAll();
        }

        // GET: api/Assignment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> Get(int id)
        {
            return await service.GetById(id);
        }

        // POST: api/Assignment
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AssignmentDto value)
        {
            var result = await service.Create(value);
            return CreatedAtAction("Get", new { id = result.IdAssignment }, result);
        }

        // PUT: api/Assignment/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] AssignmentDto value)
        {
            if (await service.Update(id, value))
            {
                return NoContent();
            }

            return NotFound();
        }

        // DELETE: api/Assignment/5
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
