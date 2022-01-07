// ***********************************************************************
// Assembly         : WebApi
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="AuthorController.cs" company="WebApi">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Application.Feautures.Author.Commands.CreateAuthorCommand;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Class AuthorController.
    /// Implements the <see cref="BaseApiController" />
    /// </summary>
    /// <seealso cref="BaseApiController" />
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    {

        /// <summary>
        /// Posts this instance.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
