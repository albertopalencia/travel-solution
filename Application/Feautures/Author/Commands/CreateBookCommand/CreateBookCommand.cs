// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="CreateBookCommand.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Feautures.Author.Commands.CreateBookCommand
{
    /// <summary>
    /// Class CreateBookCommand.
    /// Implements the <see cref="MediatR.IRequest{Application.Wrappers.Response{System.Int32}}" />
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Application.Wrappers.Response{System.Int32}}" />
    public class CreateBookCommand: IRequest<Response<int>>
    {
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>The isbn.</value>
        public int Isbn { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the sypnosis.
        /// </summary>
        /// <value>The sypnosis.</value>
        public string Sypnosis { get; set; }
        /// <summary>
        /// Gets or sets the number of pages.
        /// </summary>
        /// <value>The number of pages.</value>
        public string NumberOfPages { get; set; }
        /// <summary>
        /// Gets or sets the identifier editorial.
        /// </summary>
        /// <value>The identifier editorial.</value>
        public int IdEditorial { get; set; }
        /// <summary>
        /// Gets or sets the identifier author.
        /// </summary>
        /// <value>The identifier author.</value>
        public int IdAuthor { get; set; }


        /// <summary>
        /// Class CreateBookCommandHandler.
        /// Implements the <see cref="MediatR.IRequestHandler{Application.Feautures.Author.Commands.CreateBookCommand.CreateBookCommand, Application.Wrappers.Response{System.Int32}}" />
        /// </summary>
        /// <seealso cref="MediatR.IRequestHandler{Application.Feautures.Author.Commands.CreateBookCommand.CreateBookCommand, Application.Wrappers.Response{System.Int32}}" />
        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, Response<int>>
        {
            /// <summary>
            /// The repository
            /// </summary>
            private readonly IRepositoryAsync<Book> _repository;

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateBookCommandHandler"/> class.
            /// </summary>
            /// <param name="repository">The repository.</param>
            public CreateBookCommandHandler(IRepositoryAsync<Book> repository)
            {
                _repository = repository;
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>Response from the request</returns>
            /// <exception cref="ApiException">El codigo {request.Isbn} ya esta siendo utilizado</exception>
            public async Task<Response<int>> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                var exits = await _repository.CountAsync(new BookSpecification(request.Isbn), cancellationToken);
                if (exits > 0) throw new ApiException($"El codigo {request.Isbn} ya esta siendo utilizado");
                var book = new Book(request.Title, request.Sypnosis, request.NumberOfPages, request.Isbn,
                    new Domain.Entities.Author { Id = request.IdAuthor });
                await _repository.AddAsync(book, default);
                return new Response<int>(book.Isbn);
            }
        }
    }
}