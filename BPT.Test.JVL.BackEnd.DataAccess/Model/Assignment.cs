using System.ComponentModel.DataAnnotations.Schema;

namespace BPT.Test.JVL.BackEnd.DataAccess.DAOs
{
    [Table("asignaciones")]
    public class Assignment
    {
        [Column("IdAsignacion")]
        public int IdAssignment { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }
    }
}
