using AutoMapper;
using BPT.Test.JVL.BackEnd.DataAccess;
using BPT.Test.JVL.BackEnd.DataAccess.DAOs;
using BPT.Test.JVL.BackEnd.Services.DTOs;
using BPT.Test.JVL.BackEnd.Services.IServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.Services
{
    public class AssignmentStudentService : IAssignmentStudentService
    {
        private readonly BPTDbContext context;
        private readonly IMapper mapper;

        public AssignmentStudentService(BPTDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AssignmentStudentDto> Create(AssignmentStudentDto student)
        {
            var result = await context.AssignmentStudents.Where(c => c.Id == student.Id).ToListAsync();
            if (!result.Any())
            {
                var estudiantesDAO = mapper.Map<AssignmentStudent>(student);
                await context.AddAsync(estudiantesDAO);
                await context.SaveChangesAsync();
                return student;
            }

            return mapper.Map<AssignmentStudentDto>(result.First());
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
                            .Where(c => c.Id == id)
                            .ToListAsync();

            if (result.Any())
            {
                return mapper.Map<List<AssignmentStudentDto>>(result);
            }

            return new List<AssignmentStudentDto>();
        }

        public async Task<bool> Remove(int Id)
        {
            bool flag = false;
            var result = await context.AssignmentStudents.Where(c => c.Id == Id).ToListAsync();
            if (result.Any())
            {
                context.Remove(result.First());
                await context.SaveChangesAsync();
                return flag = true;
            }

            return flag;
        }
    }
}
