using System.ComponentModel.DataAnnotations;

namespace BPT.Test.JVL.BackEnd.Services.DTOs
{
    public class AssignmentDto
    {
        public int IdAssignment { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
