// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="GetAllBookQuery.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Application.Specifications;
using Application.Wrappers;
using AutoMapper;
using MediatR;

namespace Application.Feautures.Book.Queries.GetAllBook
{
    /// <summary>
    /// Class GetAllBookQuery.
    /// Implements the <see cref="BookDto" />
    /// </summary>
    /// <seealso cref="BookDto" />
    public class GetAllBookQuery : IRequest<PagedResponse<List<BookDto>>>
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


        /// <summary>
        /// Class GetAllBookQueryHandler.
        /// Implements the <see cref="BookDto" />
        /// </summary>
        /// <seealso cref="BookDto" />
        public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, PagedResponse<List<BookDto>>>
        {

            private readonly IRepositoryAsync<Domain.Entities.Book> _repository;
            private readonly IMapper _mapper;

            public GetAllBookQueryHandler(IRepositoryAsync<Domain.Entities.Book> repository, IMapper mapper)
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
            /// <exception cref="System.NotImplementedException"></exception>
            public async Task<PagedResponse<List<BookDto>>> Handle(GetAllBookQuery request, CancellationToken cancellationToken)
            {
                var books = await _repository.ListAsync(new PagedBookSpecification(request.PageSize, request.PageNumber), cancellationToken);
                var booksDto = _mapper.Map<List<BookDto>>(books).ToList();
                return new PagedResponse<List<BookDto>>(booksDto, request.PageNumber, request.PageSize);
            }
        }
    }
}