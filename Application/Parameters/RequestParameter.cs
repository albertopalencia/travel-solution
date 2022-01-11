// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="RequestParameter.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Application.Parameters
{
    /// <summary>
    /// Class RequestParameter.
    /// </summary>
    public class RequestParameter
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

        public RequestParameter()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequestParameter"/> class.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        public RequestParameter(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}