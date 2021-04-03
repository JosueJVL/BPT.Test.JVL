using BPT.Test.JVL.BackEnd.Services.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BPT.Test.JVL.BackEnd.Services.IServices
{
    public interface IAssignmentService
    {
        Task<List<AssignmentDto>> GetAll();
        Task<AssignmentDto> GetById(int id);
        Task<AssignmentDto> Create(AssignmentDto student);
        Task<bool> Update(int id, AssignmentDto student);
        Task<bool> Remove(int Id);
    }
}
