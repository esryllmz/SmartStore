using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Models.Dtos.Users.Requests;
using SmartStore.Services.Abstracts;

namespace SmartStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService _authenticaitonService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest request)
        {
            var result = await _authenticaitonService.LoginAsync(request);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterRequest request)
        {
            var result = await _authenticaitonService.RegisterAsync(request);
            return Ok(result);
        }
    }
}
    