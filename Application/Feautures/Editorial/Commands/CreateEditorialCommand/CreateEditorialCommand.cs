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
using Application.Wrappers;
using MediatR;

namespace Application.Feautures.Editorial.Commands.CreateEditorialCommand
{
    /// <summary>
    /// Class CreateBookCommand.
    /// Implements the <see cref="MediatR.IRequest{Response{int}}" />
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Response{int}}" />
    public class CreateEditorialCommand: IRequest<Response<int>>
    {
        /// <summary>
        /// Gets or sets the isbn.
        /// </summary>
        /// <value>The isbn.</value>
        public string Name { get; set; }
        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Campus { get; set; }


        /// <summary>
        /// Class CreateBookCommandHandler.
        /// Implements the <see cref="MediatR.IRequestHandler{Application.Feautures.Author.Commands.CreateBookCommand.CreateBookCommand, Application.Wrappers.Response{System.Int32}}" />
        /// </summary>
        /// <seealso cref="MediatR.IRequestHandler{Application.Feautures.Author.Commands.CreateBookCommand.CreateBookCommand, Application.Wrappers.Response{System.Int32}}" />
        public class CreateEditorialCommandHandler : IRequestHandler<CreateEditorialCommand, Response<int>>
        {
            /// <summary>
            /// The repository
            /// </summary>
            private readonly IRepositoryAsync<Domain.Entities.Editorial> _repository;

           
            public CreateEditorialCommandHandler(IRepositoryAsync<Domain.Entities.Editorial> repository)
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
            public async Task<Response<int>> Handle(CreateEditorialCommand request, CancellationToken cancellationToken)
            {
                var editorial = new Domain.Entities.Editorial(request.Name, request.Campus);
                await _repository.AddAsync(editorial, cancellationToken);
                return new Response<int>(editorial.Id);
            }
        }
    }
}