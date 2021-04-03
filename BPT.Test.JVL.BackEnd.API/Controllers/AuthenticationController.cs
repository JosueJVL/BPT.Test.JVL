using BPT.Test.JVL.BackEnd.Services.DTOs;
using BPT.Test.JVL.BackEnd.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BPT.Test.JVL.BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJwTAuthenticationService jwTAuthenticationService;

        /// <summary>
        /// Contructor de la Clase
        /// </summary>
        public AuthenticationController(IJwTAuthenticationService jwTAuthenticationService)
        {
            this.jwTAuthenticationService = jwTAuthenticationService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]UserModel login)
        {
            var tokenString = jwTAuthenticationService.Authenticate(login.Username, login.Password);
            if (string.IsNullOrEmpty(tokenString))
            {
                return Unauthorized();
            }

            return Ok(tokenString);
        }
    }
}