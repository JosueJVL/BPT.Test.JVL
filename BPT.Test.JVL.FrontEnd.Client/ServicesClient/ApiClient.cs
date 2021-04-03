using BPT.Test.JVL.FrontEnd.Client.Model;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BPT.Test.JVL.FrontEnd.Client.Client
{
    public class ApiClient
    {
        private static Uri generationUri;
        private string controller;
        private static string token;

        private static string Url
        {
            get
            {
                return "http://localhost:59626/api/";
            }
        }

        public ApiClient(string controller)
        {
            this.controller = controller;
        }

        protected Uri GenerationUri
        {
            get
            {
                return new Uri(new Uri(Url), controller);
            }
        }

        protected string Token
        {
            get
            {
                if (string.IsNullOrEmpty(token))
                {
                    token = Authentication();
                }

                return token;
            }
        }

        private string Authentication()
        {
            try
            {
                string result = string.Empty;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://localhost:59626/api/Authentication");
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                var authentificationInf = new { username = "bptjvl", password = "!12345qwe" };
                string serializedItem = JsonConvert.SerializeObject(authentificationInf);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(serializedItem);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode == HttpStatusCode.OK)
                {
                    using Stream webStream = httpWebResponse.GetResponseStream();
                    if (webStream != null)
                    {
                        using StreamReader responseReader = new StreamReader(webStream);
                        return responseReader.ReadToEnd();
                    }
                }

                return result;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return "A ocurrido un error";
            }
        }

        public string Get()
        {
            string result = string.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(GenerationUri);
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + Token);
            httpWebRequest.Accept = "application/json";

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode == HttpStatusCode.OK) 
            {
                using Stream webStream = httpWebResponse.GetResponseStream();
                if (webStream != null)
                {
                    using (StreamReader responseReader = new StreamReader(webStream))
                    {
                        return responseReader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public string GetById(int id)
        {
            string result = string.Empty;

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}", GenerationUri, id.ToString()));
            httpWebRequest.Method = "GET";
            httpWebRequest.Headers.Add("Authorization", "Bearer " + Token);
            httpWebRequest.Accept = "application/json";

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            if (httpWebResponse.StatusCode == HttpStatusCode.OK)
            {
                using (Stream webStream = httpWebResponse.GetResponseStream())
                {
                    if (webStream != null)
                    {
                        using (StreamReader responseReader = new StreamReader(webStream))
                        {
                            return responseReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }

        public string AddStudent<T>(T elemento)
        {
            try
            {
                string result = string.Empty;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(GenerationUri);
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Token);
                string serializedItem = JsonConvert.SerializeObject(elemento);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(serializedItem);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode == HttpStatusCode.Created)
                {
                    result = "Se agrego el Registro";
                }
                else
                {
                    result = "No se pudo actualizar el Registro";
                }

                return result;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return "A ocurrido un error";
            }
        }

        public string Update<T>(T studentModel, int id)
        {
            try
            {
                string result = string.Empty;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}", GenerationUri, id.ToString()));
                httpWebRequest.Method = "PUT";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Token);
                string serializedItem = JsonConvert.SerializeObject(studentModel);
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(serializedItem);
                }
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    result = "Se actualizo el Registro";
                }
                else
                {
                    result = "No se pudo actualizar el Registro";
                }
               
                return result;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return "A ocurrido un error";
            }
        }

        public string Delete(string id)
        {
            try
            {
                string result = string.Empty;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(string.Format("{0}/{1}", GenerationUri, id.ToString()));
                httpWebRequest.Method = "DELETE";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("Authorization", "Bearer " + Token);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                if (httpWebResponse.StatusCode == HttpStatusCode.NoContent)
                {
                    result = "Se elimino el Registro";
                }
                else
                {
                    result = "No se pudo Actualizar el Estudiante";
                }

                return result;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex);
                return "A ocurrido un error";
            }
        }

    }
}
