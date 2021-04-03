using AutoMapper;
using BPT.Test.JVL.BackEnd.DataAccess.DAOs;
using BPT.Test.JVL.BackEnd.Services.DTOs;

namespace BPT.Test.JVL.BackEnd.Services.Helpers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            this.DataMapper();
        }

        private void DataMapper()
        {
            CreateMap<Students, StudentsDto>();
            CreateMap<StudentsDto, Students>();

            CreateMap<Assignment, AssignmentDto>();
            CreateMap<AssignmentDto, Assignment>();


            CreateMap<AssignmentStudent, AssignmentStudentDto>();
            CreateMap<AssignmentStudentDto, AssignmentStudent>();
            
        }
    }
}
