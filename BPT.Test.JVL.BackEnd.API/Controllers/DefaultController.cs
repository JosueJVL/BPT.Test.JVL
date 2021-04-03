using Microsoft.AspNetCore.Mvc;

namespace BPT.Test.JVL.BackEnd.API.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        [HttpGet]
        public string Index()
        {
            return "Runing ...";
        }
    }
}