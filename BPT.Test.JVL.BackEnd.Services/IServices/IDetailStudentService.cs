using BPT.Test.JVL.BackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.IServices
{
    public interface IDetailStudentService
    {
        Task<List<AssignmentStudentDto>> GetAll();
        Task<List<AssignmentStudentDto>> GetById(int id);
    }
}
