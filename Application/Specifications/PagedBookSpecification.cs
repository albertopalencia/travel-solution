// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="PagedBookSpecification.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    /// <summary>
    /// Class PagedBookSpecification.
    /// Implements the <see cref="Specification{Book}" />
    /// </summary>
    /// <seealso cref="Specification{Book}" />
    public sealed class PagedBookSpecification : Specification<Book>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="PagedBookSpecification" /> class.
        /// </summary>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="pageNumber">The page number.</param>
        public PagedBookSpecification(int pageSize, int pageNumber)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize).AsNoTrackingWithIdentityResolution();
        }
    }
}