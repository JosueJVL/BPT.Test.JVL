using BPT.Test.JVL.BackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.IServices
{
    public interface IStudentService
    {
        Task<List<StudentsDto>> GetStudents();
        Task<StudentsDto> GetStudentById(int id);
        Task<StudentsDto> Create(StudentsDto student);
        Task<bool> Update(int id, StudentsDto student);
        Task<bool> Remove(int Id);
    }
}
