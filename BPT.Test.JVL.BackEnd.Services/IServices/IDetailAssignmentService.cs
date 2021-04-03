using BPT.Test.JVL.BackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.IServices
{
    public interface IDetailAssignmentService
    {
        Task<List<AssignmentStudentDto>> GetAll();
        Task<List<AssignmentStudentDto>> GetById(int id);
    }
}
