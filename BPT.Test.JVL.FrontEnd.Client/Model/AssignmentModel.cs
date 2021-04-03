using Newtonsoft.Json;

namespace BPT.Test.JVL.FrontEnd.Client.Model
{
    public class AssignmentModel
    {
        [JsonProperty("IdAssignment")]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
