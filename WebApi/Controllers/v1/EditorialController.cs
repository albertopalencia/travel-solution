
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    [Authorize(Roles = "Admin")]
    public class EditorialController : BaseApiController
    {
        [HttpGet()]
        public IActionResult Get()
        {
            return Ok(1);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] CreateEditorialCommand command)
        //{
        //    return Ok(Mediator.Send(command));
        //}
    }
}