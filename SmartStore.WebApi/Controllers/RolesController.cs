using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartStore.Models.Dtos.Users.Requests;
using SmartStore.Services.Abstracts;

namespace SmartStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController(IRoleService _roleService) : ControllerBase
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddRoleAsync([FromBody] string roleName)
        {
            var result = await _roleService.AddRoleAsync(roleName);

            return Ok(result);
        }

        [HttpPost("addRoleToUser")]
        public async Task<IActionResult> AddRoleToUserAsync([FromBody] AddRoleToUserRequest request)
        {
            var result = await _roleService.AddRoleToUser(request);

            return Ok(result);
        }

        [HttpGet("getAllRolesByUserId/{userId}")]
        public async Task<IActionResult> GetAllRolesByUserId([FromRoute] string userId)
        {
            var roles = await _roleService.GetAllRolesByUserId(userId);

            return Ok(roles);
        }
    }
}
