using BPT.Test.JVL.FrontEnd.Client.Client;
using BPT.Test.JVL.FrontEnd.Client.Student;
using System;

namespace BPT.Test.JVL.FrontEnd.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        public static void Start()
        {
            Console.WriteLine("Consolo de Informacion");
            Console.WriteLine("1.- Estudiantes, 2.- Asignaciones, 3.- Asignacion de Estudiantes");
            Console.WriteLine("4.- Detalle de Asignaciones por Id Asignacion, 5.- Detalle de Asignaciones por Id Estudiante");
            Console.WriteLine("Ingresa el Id del Modulo, Enter al Finalizar");
            var modul = Convert.ToInt32(Console.ReadLine());
            switch (modul)
            {
                case 1:
                    var student = new Students();
                    student.StudentInformation();
                    break;
                case 2:
                    var assignment = new Assignment();
                    assignment.Information();
                    break;
                case 3:
                    var assignmentStudent = new AssignmentStudent();
                    assignmentStudent.Information();
                    break;
                case 4:
                    var detailAssignment = new DetailAssignment();
                    detailAssignment.Information();
                    break;
                case 5:
                    var detailStudent = new DetailStudent();
                    detailStudent.Information();
                    break;
            }

        }
    }
}
