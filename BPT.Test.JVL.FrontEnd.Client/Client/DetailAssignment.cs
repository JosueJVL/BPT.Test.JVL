using BPT.Test.JVL.FrontEnd.Client.Model;
using BPT.Test.JVL.FrontEnd.Client.ServicesClient;
using System;
using System.Linq;

namespace BPT.Test.JVL.FrontEnd.Client.Client
{
    public class DetailAssignment
    {
        public void Information()
        {
            Console.WriteLine("******* D E T A L L E    DE   A S I G N A C I O N E S  POR  ID   A S I G N A C I O N  *******");
            Console.WriteLine("*******    (1)Consultar, (2)Consulta por Id Asignacion, (3)Salir *******");
            Console.WriteLine("*******           Ingresa el Numero del Modulo, Enter al Finalizar        *******");
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
                    Console.WriteLine("Ingresa el ID de la Asignacion ");
                    var id = Convert.ToInt32(Console.ReadLine());

                    this.GetById(id);
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
            var student = new ServiceClient("DetailAssignment");
            var result = student.GetAll<AssignmentStudentModel>();
            if (result.Any())
            {
                result.ForEach(c =>
                {
                    Console.WriteLine(string.Format("                     Id Asignacion de Estudiante {0}",
                        c.Id.ToString()));

                    Console.WriteLine(string.Format("       ID  Estudiante {0} - Id Asignacion  {1}",
                        c.IdStudent.ToString(), c.IdAssigment.ToString()));
                    if (c.StudentsDto != null)
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

        private void GetById(int id)
        {
            var student = new ServiceClient("DetailAssignment");
            var result = student.GetById<AssignmentStudentModel>(id);
            if (result.Any())
            {
                result.ForEach(c =>
                {
                    Console.WriteLine(string.Format("                     Id Asignacion de Estudiante {0}",
                        c.Id.ToString()));

                    Console.WriteLine(string.Format("       ID  Estudiante {0} - Id Asignacion  {1}",
                        c.IdStudent.ToString(), c.IdAssigment.ToString()));
                    if (c.StudentsDto != null)
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
    }
}
