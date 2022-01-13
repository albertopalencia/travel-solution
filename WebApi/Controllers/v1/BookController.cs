// ***********************************************************************
// Assembly         : WebApi
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="BookController.cs" company="WebApi">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using Application.Feautures.Book.Commands.CreateBookCommand;
using Application.Feautures.Book.Queries.GetAllBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers.v1
{
    /// <summary>
    /// Book's api
    /// Implements the <see cref="WebApi.Controllers.BaseApiController" />
    /// </summary>
    /// <seealso cref="WebApi.Controllers.BaseApiController" />
    [ApiVersion("1.0")]
    public class BookController : BaseApiController
    {
        #region Methods
        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllBookParameters filter)
        {
            return Ok(await Mediator.Send(new GetAllBookQuery{ PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }


        /// <summary>
        /// Posts the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateBookCommand command)
        {
          return Ok(await Mediator.Send(command));
        }

        #endregion
    }
}