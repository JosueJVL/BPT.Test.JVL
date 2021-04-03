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
    public class AssignmentService : IAssignmentService
    {
        private readonly BPTDbContext context;
        private readonly IMapper mapper;

        public AssignmentService(BPTDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AssignmentDto> Create(AssignmentDto model)
        {
            try
            {
                var result = await context.Assignments.Where(c => c.IdAssignment == model.IdAssignment).ToListAsync();
                if (!result.Any())
                {
                    await context.AddAsync(new Assignment { Name = model.Name });
                    await context.SaveChangesAsync();
                    return model;
                }

                return mapper.Map<AssignmentDto>(result.First());
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task<AssignmentDto> GetById(int id)
        {
            var result = await context.Assignments.Where(c => c.IdAssignment == id).ToListAsync();
            if (result.Any())
            {
                return mapper.Map<AssignmentDto>(result.First());
            }

            return new AssignmentDto();
        }

        public async Task<List<AssignmentDto>> GetAll()
        {
            var result = await context.Assignments.ToListAsync();
            if (result.Any())
            {
                return mapper.Map<List<AssignmentDto>>(result);
            }

            return new List<AssignmentDto>();
        }

        public async Task<bool> Remove(int id)
        {
            bool flag = false;
            var result = await context.Assignments.Where(c => c.IdAssignment == id).ToListAsync();
            var resultAsignment = await context.AssignmentStudents.Where(c => c.IdAssigment == id).ToListAsync();
            if (resultAsignment.Any())
            {
                resultAsignment.ForEach(async c => {
                    context.Remove(c);
                    await context.SaveChangesAsync();
                });
            }

            if (result.Any())
            {
                context.Remove(result.First());
                await context.SaveChangesAsync();
                return flag = true;
            }

            return flag;
        }

        public async Task<bool> Update(int id, AssignmentDto model)
        {
            bool flag = false;
            var result = await context.Assignments.Where(c => c.IdAssignment == id).ToListAsync();
            if (result.Any())
            {
                result.First().Name = model.Name;
                await context.SaveChangesAsync();
                return flag = true;
            }

            return flag;
        }
    }
}
