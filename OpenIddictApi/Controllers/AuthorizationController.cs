using Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OpenIddictApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]/[action]")]
    public class AuthorizationController : ControllerBase
    {

        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController(ILogger<AuthorizationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Response Authorize([FromQuery] string code, [FromQuery] string state)
        {
            return new Response
            {
                Code = 302,
                Data = new
                {
                    Code = code,
                    State = state
                },
                Message = "Found",
                Success = true
            };
        }

        [HttpGet]
        public Response Token([FromBody] TokenDto token)
        {
            return new Response
            {
                Code = 200,
                Data = token,
                Message = "success",
                Success = true
            };
        }
    }
}