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
    public class StudentService : IStudentService
    {
        private readonly BPTDbContext context;
        private readonly IMapper mapper;

        public StudentService(BPTDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public async Task<StudentsDto> Create(StudentsDto student)
        {
            var result = await context.Students.Where(c => c.IdStudent == student.IdStudent).ToListAsync();
            if (!result.Any())
            {
                var estudiantesDAO = mapper.Map<Students>(student);
                await context.AddAsync(estudiantesDAO);
                await context.SaveChangesAsync();
                return student;
            }

            return mapper.Map<StudentsDto>(result.First());
        }

        public async Task<StudentsDto> GetStudentById(int id)
        {
            var result = await context.Students.Where(c => c.IdStudent == id).ToListAsync();
            if (result.Any())
            {
                return mapper.Map<StudentsDto>(result.First());
            }

            return new StudentsDto();
        }

        public async Task<List<StudentsDto>> GetStudents()
        {
            var result = await context.Students.ToListAsync();
            if (result.Any())
            {
                return mapper.Map<List<StudentsDto>>(result);
            }

            return new List<StudentsDto>();
        }

        public async Task<bool> Remove(int Id)
        {
            bool flag = false;
            var result = await context.Students.Where(c => c.IdStudent == Id).ToListAsync();
            if (result.Any())
            {
                context.Remove(result.First());
                await context.SaveChangesAsync();
                return flag = true;
            }

            return flag;
        }

        public async Task<bool> Update(int id, StudentsDto student)
        {
            bool flag = false;
            var result = await context.Students.Where(c => c.IdStudent == id).ToListAsync();
            if (result.Any())
            {
                result.First().Name = student.Name;
                result.First().BirthDate = student.BirthDate;
                await context.SaveChangesAsync();
                return flag = true;
            }

            return flag;
        }
    }
}
