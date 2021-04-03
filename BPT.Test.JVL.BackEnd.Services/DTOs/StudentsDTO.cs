using System;
using System.ComponentModel.DataAnnotations;

namespace BPT.Test.JVL.BackEnd.Services.DTOs
{
    public class StudentsDto
    {
        public int IdStudent { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }
    }
}
