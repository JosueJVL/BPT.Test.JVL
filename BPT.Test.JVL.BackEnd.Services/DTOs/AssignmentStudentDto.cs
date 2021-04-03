using System.Collections.Generic;

namespace BPT.Test.JVL.BackEnd.Services.DTOs
{
    public class AssignmentStudentDto
    {
        public int Id { get; set; }
        public int IdAssigment { get; set; }
        public int IdStudent { get; set; }
        public StudentsDto StudentsDto { get; set; }
        public List<AssignmentDto> AssignmentDto { get; set; }
    }
}
