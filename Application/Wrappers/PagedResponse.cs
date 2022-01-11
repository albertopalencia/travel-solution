// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="PagedResponse.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Application.Wrappers
{
    /// <summary>
    /// Class PagedResponse.
    /// Implements the <see cref="Application.Wrappers.Response{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Application.Wrappers.Response{T}" />
    public class PagedResponse<T> : Response<T>
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
        /// Initializes a new instance of the <see cref="PagedResponse{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        public PagedResponse(T data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Succeeded = true;
            Errors = null;
        }
    }
}