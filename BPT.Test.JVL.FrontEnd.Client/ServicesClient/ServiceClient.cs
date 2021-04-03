using BPT.Test.JVL.FrontEnd.Client.Client;
using BPT.Test.JVL.FrontEnd.Client.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BPT.Test.JVL.FrontEnd.Client.ServicesClient
{
    public class ServiceClient
    {
        private readonly string type;

        public ServiceClient(string type)
        {
            this.type = type;
        }
        public List<T> GetAll<T>()
        {
            var client = new ApiClient(type);
            var response = client.Get();
            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<List<T>>(response);
            }

            return new List<T>();
        }


        public List<T> GetById<T>(int id)
        {
            var client = new ApiClient(type);
            var response = client.GetById(id);
            if (!string.IsNullOrEmpty(response))
            {
                return JsonConvert.DeserializeObject<List<T>>(response);
            }

            return new List<T>();
        }

        public string Create<T>(T student)
        {
            var client = new ApiClient(type);
            return client.AddStudent(student);
            
        }

        public string Delete(string id)
        {
            var client = new ApiClient(type);
            return client.Delete(id);
        }

        public string Update<T>(T student, int id)
        {
            var client = new ApiClient(type);
            return client.Update(student, id);
        }
    }
}
