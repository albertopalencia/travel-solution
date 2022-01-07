// ***********************************************************************
// Assembly         : Domain
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Author.cs" company="Domain">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.Collections.Generic;

namespace Domain.Entities
{
    /// <summary>
    /// Class Author.
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Author"/> class.
        /// </summary>
        public Author()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Author" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="lastName">The last name.</param>
        /// <param name="authorsHasBooks">The authors has books.</param>
        /// <param name="id">The identifier.</param>
        public Author(string name, string lastName, ICollection<AuthorHasBook> authorsHasBooks, int? id = null)
        {
            Name = name;
            LastName = lastName;
            AuthorsHasBooks = authorsHasBooks;
            Id = id ?? 0;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets the lastname.
        /// </summary>
        /// <value>The lastname.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the authors has books.
        /// </summary>
        /// <value>The authors has books.</value>
        public virtual ICollection<AuthorHasBook> AuthorsHasBooks { get; }
    }

}
