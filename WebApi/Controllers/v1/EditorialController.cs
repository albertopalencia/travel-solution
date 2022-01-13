
using Application.Feautures.Editorial.Commands.CreateEditorialCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Feautures.Editorial.Queries.GetAllEditorial;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class EditorialController : BaseApiController
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllEditorialQuery()));
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateEditorialCommand command)
        {
            return Ok( await Mediator.Send(command));
        }
    }
}