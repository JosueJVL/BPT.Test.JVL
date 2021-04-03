using BPT.Test.JVL.FrontEnd.Client.Model;
using BPT.Test.JVL.FrontEnd.Client.ServicesClient;
using System;
using System.Linq;

namespace BPT.Test.JVL.FrontEnd.Client.Client
{
    class AssignmentStudent
    {
        public void Information()
        {
            Console.WriteLine("*******  A S I G N A C I O N E S  POR E S T U D I A N T E S              *******");
            Console.WriteLine("*******  (1)Consultar, (2)Eliminar, (3)Insertar, (4)Salir *******");
            Console.WriteLine("*******          Ingresa el Numero del Modulo, Enter al Finalizar        *******");
            var operation = Convert.ToInt32(Console.ReadLine());


            switch (operation)
            {
                case 1:
                    Get();
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Information();
                    break;
                case 2:
                    Console.WriteLine(" ---------------  Primero se mostraran la Existencia de los Registros");
                    Get();

                    Console.WriteLine("Ingresa el ID del Registro a Eliminar, Enter al Finalizar");
                    var idReg = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(this.Delete(idReg));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Information();
                    break;
                case 3:
                    Console.WriteLine("Ingresa el ID de la Asignacion, Enter al Finalizar");
                    var idAssignments = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el del Estudiante, Enter al Finalizar");
                    var idStudents = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine(this.Create(new AssignmentStudentModel() { IdAssigment = idAssignments, IdStudent = idStudents }));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Information();
                    break;
                default:
                    Program.Start();
                    return;
            }
        }

        private void Get()
        {
            var student = new ServiceClient("AssignmentStudent");
            var result = student.GetAll<AssignmentStudentModel>();
            if (result.Any())
            {
                result.ForEach(c =>
                {
                    Console.WriteLine(string.Format("                     Id Asignacion de Estudiante {0}",
                        c.Id.ToString()));

                    Console.WriteLine(string.Format("       ID  Estudiante {0} - Id Asignacion  {1}", 
                        c.IdStudent.ToString(), c.IdAssigment.ToString()));
                    if(c.StudentsDto != null)
                    {
                        Console.WriteLine(string.Format("       ID {0} - Nombre del Estudiante {1} Fecha de Nacimiento {2} ",
                        c.StudentsDto.Id.ToString(), c.StudentsDto.Name.ToString(), c.StudentsDto.BirthDate.ToString()));
                    }
                    if (c.AssignmentDto.Any())
                    {
                        Console.WriteLine(string.Format("       ID {0}- Asignacion  Nombre {1} ",
                        c.AssignmentDto.First().Id, c.AssignmentDto.First().Name.ToString()));
                    }
                    Console.WriteLine("\n");
                });
            }
            else
            {
                Console.WriteLine("No se encontraron Registros");
            }

        }

        private string Create(AssignmentStudentModel model)
        {
            var student = new ServiceClient("AssignmentStudent");
            return student.Create(model);

        }

        private string Delete(string id)
        {
            var student = new ServiceClient("AssignmentStudent");
            return student.Delete(id);
        }
    }
}
