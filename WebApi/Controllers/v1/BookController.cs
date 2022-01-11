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
using Application.Feautures.Author.Commands.CreateBookCommand;
using Application.Feautures.Author.Queries.GetAllBook;
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
    [Authorize(Roles = "Admin")]
    public class BookController : BaseApiController
    {
        #region Methods
        /// <summary>
        /// Gets the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>IActionResult.</returns>
        [HttpGet]
        public IActionResult Get([FromQuery] GetAllBookParameters filter)
        {
            return Ok(Mediator.Send(new GetAllBookQuery{ PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }


        /// <summary>
        /// Posts the specified command.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>IActionResult.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] CreateBookCommand command)
        {
            //var authors = model.Authors.Select(it => new Author(it.Name, it.LastName, it.Id)).ToArray();
            //var result = bookService.AddBook(model.ISBN, model.Title, model.Sypnosis, model.NumberPages, new Editorial(model.Editorial.Name, model.Editorial.Campus, model.Editorial.Id), authors);
            return Ok(Mediator.Send(command));
            
        } 

        #endregion
    }
}