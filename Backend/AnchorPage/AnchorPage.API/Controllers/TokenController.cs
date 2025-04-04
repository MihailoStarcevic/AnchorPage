using AnchorPage.API.Core;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnchorPage.API.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly JwtManager _manager;

        public TokenController(JwtManager manager)
        {
            _manager = manager;
        }

        // POST api/<TokenController>
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequest request)
        {
            var token = _manager.MakeToken(request.UserLogin, request.Password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { token });
        }

        public class LoginRequest
        {
            public string UserLogin { get; set; } = string.Empty;
            public string Password { get; set; } = string.Empty;
        }

        //Endpoint for keeping Azure App Service alive
        [Route("/keepalive")]
        public string Get()
        {
            return "Hi there!";
        }
    }
}
