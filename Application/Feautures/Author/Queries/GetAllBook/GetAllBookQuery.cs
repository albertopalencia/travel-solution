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

using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Specifications;

namespace Application.Feautures.Author.Queries.GetAllBook
{
    /// <summary>
    /// Class GetAllBookQuery.
    /// Implements the <see cref="MediatR.IRequest{Application.Wrappers.PagedResponse{System.Collections.Generic.List{Application.DTOs.BookDto}}}" />
    /// </summary>
    /// <seealso cref="MediatR.IRequest{Application.Wrappers.PagedResponse{System.Collections.Generic.List{Application.DTOs.BookDto}}}" />
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
        /// Implements the <see cref="MediatR.IRequestHandler{Application.Feautures.Author.Queries.GetAllBook.GetAllBookQuery, Application.Wrappers.PagedResponse{System.Collections.Generic.List{Application.DTOs.BookDto}}}" />
        /// </summary>
        /// <seealso cref="MediatR.IRequestHandler{Application.Feautures.Author.Queries.GetAllBook.GetAllBookQuery, Application.Wrappers.PagedResponse{System.Collections.Generic.List{Application.DTOs.BookDto}}}" />
        public class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, PagedResponse<List<BookDto>>>
        {

            private readonly IRepositoryAsync<Book> _repository;
            private readonly IMapper _mapper;

            public GetAllBookQueryHandler(IRepositoryAsync<Book> repository, IMapper mapper)
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
                var booksDto = _mapper.Map<List<BookDto>>(books);
                return new PagedResponse<List<BookDto>>(booksDto, request.PageNumber, request.PageSize);

            }
        }
    }
}