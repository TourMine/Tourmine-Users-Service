using Microsoft.AspNetCore.Mvc;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpPost("v1/register")]
        public async Task<IActionResult> Register([FromBody] UserRequest request, [FromServices] IRegisterUserUseCase useCase)
        {
            var result = await useCase.Execute(request);
            return Ok(result);
        }

        [HttpGet("v1/{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id, [FromServices] IGetByIdUseCase useCase)
        {
            var result = await useCase.Execute(id);
            return Ok(result);
        }

        [HttpGet("v1/get-by-email")]
        public async Task<IActionResult> GetByEmail([FromQuery] string email, [FromServices] IGetByEmailUseCase useCase)
        {
            var result = await useCase.Execute(email);
            return Ok(result);
        }
    }
}
