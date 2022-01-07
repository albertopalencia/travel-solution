// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="CreateAuthorCommand.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Interfaces;
using AutoMapper;

namespace Application.Feautures.Author.Commands.CreateAuthorCommand
{
    /// <summary>
    /// Class CreateAuthorCommand.
    /// Implements the <see cref="MediatR.IRequest{Response{int}}" />
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Response{int}}" />
    public class CreateAuthorCommand : IRequest<Response<int>>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }
    }

    /// <summary>
    /// Class CreateAuthorCommandHandler.
    /// Implements the <see cref="MediatR.IRequestHandler{CreateAuthorCommand, Response{int}}" />
    /// </summary>
    /// <seealso cref="MediatR.IRequestHandler{CreateAuthorCommand, Response{int}}" />
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, Response<int>>
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IRepositoryAsync<Domain.Entities.Author> _repository;
        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAuthorCommandHandler"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public CreateAuthorCommandHandler(IRepositoryAsync<Domain.Entities.Author> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        /// <summary>
        /// Handles a request
        /// </summary>
        /// <param name="request">The request</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Response from the request</returns>
        public async Task<Response<int>> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
           var author = _mapper.Map<Domain.Entities.Author>(request);
           var data = await _repository.AddAsync(author, cancellationToken);
           return new Response<int>(data.Id);
        }
    }
}