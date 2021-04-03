using BPT.Test.JVL.FrontEnd.Client.Model;
using BPT.Test.JVL.FrontEnd.Client.ServicesClient;
using System;
using System.Linq;

namespace BPT.Test.JVL.FrontEnd.Client.Student
{
    public class Students
    {
        public void StudentInformation()
        {
            Console.WriteLine("*******                               E S T U D I A N T E                *******");
            Console.WriteLine("*******  (1)Consultar, (2)Actualizar, (3)Eliminar, (4)Insertar, (5)Salir *******");
            Console.WriteLine("*******          Ingresa el Numero del Modulo, Enter al Finalizar        *******");
            var operation = Convert.ToInt32(Console.ReadLine());


            switch (operation)
            {
                case 1:
                    GetStudents();
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    StudentInformation();
                    break;
                case 2:
                    Console.WriteLine(" ---------------  Primero se mostraran a los Estudiantes existentes");
                    GetStudents();

                    Console.WriteLine("Ingresa el ID del Estudiante Actualizar, Enter al Finalizar");
                    var id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Nombre del Estudiante, Enter al Finalizar");
                    var name = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Ingresa la Fecha de Nacimiento YYYY-mm-dd, Enter al Finalizar");
                    var birthDate = Convert.ToDateTime(Console.ReadLine());

                    Console.WriteLine(this.UpdateStudent(new StudentsModel() { Name = name, BirthDate = birthDate, Id = id }));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    StudentInformation();
                    break;
                case 3:
                    Console.WriteLine(".... Primero se mostraran a los Estudiantes existentes");
                    GetStudents();

                    Console.WriteLine("Ingresa el ID del Estudiante a Eliminar, Enter al Finalizar");
                    var idStudent = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(this.DeleteStudent(idStudent));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    StudentInformation();
                    break;
                case 4:
                    Console.WriteLine("Ingresa el Nombre del Estudiante, Enter al Finalizar");
                    name = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Ingresa la Fecha de Nacimiento YYYY-mm-dd, Enter al Finalizar");
                    birthDate = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine(this.CreateStudent(new StudentsModel() { Name = name, BirthDate = birthDate }));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    StudentInformation();
                    break;
                default:
                    Program.Start();
                    return;
            }
        }

        private void GetStudents()
        {
            var student = new ServiceClient("Student");
            var result = student.GetAll<StudentsModel>();
            if (result.Any())
            {
                result.ForEach(c =>
                {
                    Console.WriteLine(string.Format(" --- {0} ID del Estudiante,  Nombre: {1}, Fecha de Nacimiento: {2}", c.Id.ToString(), c.Name.ToString(), c.BirthDate.ToString()));
                });
            }
            else
            {
                Console.WriteLine("No se encontraron Registros");
            }

        }

        private string CreateStudent(StudentsModel model)
        {
            var student = new ServiceClient("Student");
            return student.Create(model);
        }

        private string UpdateStudent(StudentsModel model)
        {
            var student = new ServiceClient("Student");
            return student.Update(model, model.Id);
        }

        private string DeleteStudent(string id)
        {
            var student = new ServiceClient("Student");
            return student.Delete(id);
        }
    }
}
