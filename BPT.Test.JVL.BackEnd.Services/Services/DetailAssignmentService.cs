using AutoMapper;
using BPT.Test.JVL.BackEnd.DataAccess;
using BPT.Test.JVL.BackEnd.Services.DTOs;
using BPT.Test.JVL.BackEnd.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.Services
{
    public class DetailAssignmentService : IDetailAssignmentService
    {
        private readonly BPTDbContext context;
        private readonly IMapper mapper;

        public DetailAssignmentService(BPTDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<AssignmentStudentDto>> GetAll()
        {
            var result = await context.AssignmentStudents
                                    .Include(c => c.StudentsDto)
                                    .Include(c => c.AssignmentDto)
                                    .ToListAsync();
            if (result.Any())
            {
                return mapper.Map<List<AssignmentStudentDto>>(result);
            }

            return new List<AssignmentStudentDto>();
        }

        public async Task<List<AssignmentStudentDto>> GetById(int id)
        {
            var result = await context.AssignmentStudents
                            .Include(c => c.StudentsDto)
                            .Include(c => c.AssignmentDto)
                            .Where(c => c.IdAssigment == id)
                            .ToListAsync();

            if (result.Any())
            {
                return mapper.Map<List<AssignmentStudentDto>>(result);
            }

            return new List<AssignmentStudentDto>();
        }
    }
}
