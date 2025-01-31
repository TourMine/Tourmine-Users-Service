using Microsoft.AspNetCore.Mvc;
using Tourmine.Users.Application.Interfaces;
using Tourmine.Users.Application.Requests;

namespace Tourmine.Users.WebAPI.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        [HttpPost("v1/create")]
        public async Task<IActionResult> Create([FromBody] UserRequest request, [FromServices] ICreateUserUseCase useCase)
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
    }
}
