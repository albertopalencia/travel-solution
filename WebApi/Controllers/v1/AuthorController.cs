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
using Application.Feautures.Author.Queries.GetAllAuthor;
using Microsoft.AspNetCore.Authorization;

namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Class AuthorController.
    /// Implements the <see cref="BaseApiController" />
    /// Implements the <see cref="WebApi.Controllers.BaseApiController" />
    /// </summary>
    /// <seealso cref="WebApi.Controllers.BaseApiController" />
    /// <seealso cref="BaseApiController" />
    [ApiVersion("1.0")]
    public class AuthorController : BaseApiController
    { 
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllAuthorParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllAuthorQuery{ PageNumber = filter.PageNumber, PageSize = filter.PageSize }));
        }

        /// <summary>
        /// Posts this instance.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>Task&lt;IActionResult&gt;.</returns>
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post(CreateAuthorCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}
