using BPT.Test.JVL.FrontEnd.Client.Model;
using BPT.Test.JVL.FrontEnd.Client.ServicesClient;
using System;
using System.Linq;

namespace BPT.Test.JVL.FrontEnd.Client.Client
{
    public class Assignment
    {
        public void Information()
        {
            Console.WriteLine("*******                          A S I G N A C I O N E S                 *******");
            Console.WriteLine("*******  (1)Consultar, (2)Actualizar, (3)Eliminar, (4)Insertar, (5)Salir *******");
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

                    Console.WriteLine("Ingresa el ID del Registro Actualizar, Enter al Finalizar");
                    var id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Ingresa el Nombre, Enter al Finalizar");
                    var name = Convert.ToString(Console.ReadLine());

                    Console.WriteLine(this.Update(new AssignmentModel() { Name = name, Id = id }));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Information();
                    break;
                case 3:
                    Console.WriteLine(" ---------------  Primero se mostraran la Existencia de los Registros");
                    Get();

                    Console.WriteLine("Ingresa el ID del Registro a Eliminar, Enter al Finalizar");
                    var idReg = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(this.Delete(idReg));
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    Information();
                    break;
                case 4:
                    Console.WriteLine("Ingresa el Nombre del Registro, Enter al Finalizar");
                    name = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(this.Create(new AssignmentModel() { Name = name }));
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
            var student = new ServiceClient("Assignment");
            var result = student.GetAll<AssignmentModel>();
            if (result.Any())
            {
                result.ForEach(c =>
                {
                    Console.WriteLine(string.Format(" --- {0} ID Asigancion,  Nombre: {1}", c.Id.ToString(), c.Name.ToString()));
                });
            }
            else
            {
                Console.WriteLine("No se encontraron Registros");
            }

        }

        private string Create(AssignmentModel model)
        {
            var student = new ServiceClient("Assignment");
            return student.Create(model);

        }

        private string Update(AssignmentModel model)
        {
            var student = new ServiceClient("Assignment");
            return student.Update(model, model.Id);
        }

        private string Delete(string id)
        {
            var student = new ServiceClient("Assignment");
            return student.Delete(id);
        }
    }
}
