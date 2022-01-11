// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="GetAllAuthorQuery.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Specifications;

namespace Application.Feautures.Author.Queries.GetAllAuthor
{
     
    public class GetAllAuthorQuery : IRequest<PagedResponse<List<AuthorDto>>>
    {
        /// <summary>
        /// Gets or sets the page number.
        /// </summary>
        /// <value>The page number.</value>
        public int PageNumber { get; set; }
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        public int PageSize { get; set; }

        public class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, PagedResponse<List<AuthorDto>>>
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
            /// Initializes a new instance of the <see cref="GetAllAuthorQueryHandler"/> class.
            /// </summary>
            /// <param name="repository">The repository.</param>
            /// <param name="mapper">The mapper.</param>
            public GetAllAuthorQueryHandler(IRepositoryAsync<Domain.Entities.Author> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            /// <summary>
            /// Handles a request
            /// </summary>
            /// <param name="request">The request</param>
            /// <param name="cancellationToken">Cancellation token</param>
            /// <returns>Response from the request</returns>
            public async Task<PagedResponse<List<AuthorDto>>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
            {
                var authors = await _repository.ListAsync(new PagedAuthorSpecification(request.PageSize, request.PageNumber), cancellationToken);
                var authorsDto = _mapper.Map<List<AuthorDto>>(authors);
                return new PagedResponse<List<AuthorDto>>(authorsDto, request.PageNumber, request.PageSize);
            }
        }
    }

    
   
}