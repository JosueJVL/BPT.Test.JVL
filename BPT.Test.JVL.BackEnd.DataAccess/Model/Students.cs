using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BPT.Test.JVL.BackEnd.DataAccess.DAOs
{
    [Table("estudiantes")]
    public class Students
    {
        [Key]
        [Column("IdEstudiante")]
        public int IdStudent { get; set; }

        [Column("Nombre")]
        public string Name { get; set; }

        [Column("FechaNacimiento")]
        public DateTime BirthDate { get; set; }
    }
}
