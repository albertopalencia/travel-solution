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

using Application.Exceptions;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feautures.Book.Commands.CreateBookCommand
{
    /// <summary>
    /// Class CreateBookCommand.
    /// Implements the <see cref="MediatR.IRequest{Response{int}}" />
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Response{int}}" />
    public class CreateBookCommand : IRequest<Response<int>>
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
        public string NumberPages { get; set; }
        /// <summary>
        /// Gets or sets the identifier editorial.
        /// </summary>
        /// <value>The identifier editorial.</value>
        public int EditorialId { get; set; }
        /// <summary>
        /// Gets or sets the identifier author.
        /// </summary>
        /// <value>The identifier author.</value>
        public int AuthorId { get; set; }


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
            private readonly IRepositoryAsync<Domain.Entities.Book> _repository;

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateBookCommandHandler"/> class.
            /// </summary>
            /// <param name="repository">The repository.</param>
            public CreateBookCommandHandler(IRepositoryAsync<Domain.Entities.Book> repository)
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
                var book = new Domain.Entities.Book(
                    request.EditorialId,
                    request.Title,
                    request.Sypnosis,
                    request.NumberPages,
                    request.Isbn,
                    new Domain.Entities.Author{ Id = request.AuthorId }
                );
                await _repository.AddAsync(book, cancellationToken);
                return new Response<int>(book.Isbn);
            }
        }
    }
}