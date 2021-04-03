using System;
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
    public class DetailStudentController : ControllerBase
    {
        private readonly IDetailStudentService service;

        public DetailStudentController(IDetailStudentService service)
        {
            this.service = service;
        }
        // GET: api/Detail
        [HttpGet]
        public async Task<IEnumerable<AssignmentStudentDto>> Get()
        {
            return await service.GetAll();
        }

        // GET: api/Detail/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<AssignmentStudentDto>> Get(int id)
        {
            return await service.GetById(id);
        }
    }
}