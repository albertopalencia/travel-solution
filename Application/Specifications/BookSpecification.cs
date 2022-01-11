// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="BookSpecification.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Ardalis.Specification;
using Domain.Entities;

namespace Application.Specifications
{
    /// <summary>
    /// Class BookSpecification.
    /// Implements the <see cref="Ardalis.Specification.Specification{Domain.Entities.Book}" />
    /// </summary>
    /// <seealso cref="Ardalis.Specification.Specification{Domain.Entities.Book}" />
    public class BookSpecification : Specification<Book>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookSpecification"/> class.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        public BookSpecification(int isbn)
        {
            Query.Where(s => s.Isbn == isbn);
        }
    }
}