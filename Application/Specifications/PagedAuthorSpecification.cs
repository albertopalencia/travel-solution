// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="PagedAuthorSpecification.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    /// <summary>
    /// Class PagedAuthorSpecification.
    /// Implements the <see cref="Ardalis.Specification.Specification{Domain.Entities.Author}" />
    /// </summary>
    /// <seealso cref="Ardalis.Specification.Specification{Domain.Entities.Author}" />
    public class PagedAuthorSpecification : Specification<Author>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PagedAuthorSpecification"/> class.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        public PagedAuthorSpecification(int pageSize, int pageNumber)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }
    }
}