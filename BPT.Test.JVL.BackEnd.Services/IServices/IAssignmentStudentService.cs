using BPT.Test.JVL.BackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.IServices
{
    public interface IAssignmentStudentService
    {
        Task<List<AssignmentStudentDto>> GetAll();
        Task<List<AssignmentStudentDto>> GetById(int id);
        Task<AssignmentStudentDto> Create(AssignmentStudentDto student);
        Task<bool> Remove(int Id);
    }
}
