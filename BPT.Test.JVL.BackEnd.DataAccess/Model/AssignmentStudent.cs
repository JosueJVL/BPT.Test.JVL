using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPT.Test.JVL.BackEnd.DataAccess.DAOs
{
    [Table("asignacionesEstudiantes")]
    public class AssignmentStudent
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("IdAsignacion")]
        public int IdAssigment { get; set; }
        
        [Column("IdEstudiante")]
        public int IdStudent { get; set; }
        
        [ForeignKey("IdStudent")]
        public Students StudentsDto { get; set; }

        [ForeignKey("IdAssignment")]
        public List<Assignment> AssignmentDto { get; set; }
    }
}
