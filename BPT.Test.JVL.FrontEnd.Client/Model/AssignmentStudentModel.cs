using System.Collections.Generic;

namespace BPT.Test.JVL.FrontEnd.Client.Model
{
    public class AssignmentStudentModel
    {
        public int Id { get; set; }
        public int IdAssigment { get; set; }
        public int IdStudent { get; set; }
        public StudentsModel StudentsDto { get; set; }
        public List<AssignmentModel> AssignmentDto { get; set; }
    }
}
