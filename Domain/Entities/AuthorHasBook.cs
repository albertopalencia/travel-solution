// ***********************************************************************
// Assembly         : Domain
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="AuthorHasBook.cs" company="Domain">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    /// <summary>
    /// Class AuthorHasBook.
    /// </summary>
    public class AuthorHasBook
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorHasBook"/> class.
        /// </summary>
        public AuthorHasBook()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorHasBook" /> class.
        /// </summary>
        /// <param name="author">The author.</param>
        /// <param name="isbn">The isbn.</param>
        public AuthorHasBook(Author author, int isbn)
        {
            if(author.Id > 0)
                AuthorId = author.Id;
            else
                Author = author;
            
            BookIsbn = isbn;
        }

        /// <summary>
        /// Gets the author identifier.
        /// </summary>
        /// <value>The author identifier.</value>
        [Column("Autores_Id")]
        public int AuthorId { get; }

        /// <summary>
        /// Gets the book isbn.
        /// </summary>
        /// <value>The book isbn.</value>
        [Column("Libros_ISBN")]
        public int BookIsbn { get; }
        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <value>The author.</value>
        public virtual Author Author { get; }

        /// <summary>
        /// Gets the book.
        /// </summary>
        /// <value>The book.</value>
        public virtual Book Book { get; private set; }
    }
}
