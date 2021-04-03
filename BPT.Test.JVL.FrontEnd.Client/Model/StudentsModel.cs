using Newtonsoft.Json;
using System;

namespace BPT.Test.JVL.FrontEnd.Client.Model
{
    public class StudentsModel
    {
        [JsonProperty("idStudent")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("birthDate")]
        public DateTime BirthDate { get; set; }
    }
}
