// ***********************************************************************
// Assembly         : Domain
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Book.cs" company="Domain">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    /// <summary>
    /// Class Book.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Book" /> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="sypnosis">The sypnosis.</param>
        /// <param name="numberPages">The number pages.</param>
        /// <param name="isbn">The isbn.</param>
        /// <param name="authors">The authors.</param>
        public Book(string title, string sypnosis, string numberPages, int? isbn, params Author[] authors)
        {
            Title = title;
            Sypnosis = sypnosis;
            NumberPages = numberPages;
            AddAuthors(authors);
            Isbn = isbn ?? 0;
        }

        /// <summary>
        /// Gets the isbn.
        /// </summary>
        /// <value>The isbn.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Isbn { get; }

        /// <summary>
        /// Gets the editorial identifier.
        /// </summary>
        /// <value>The editorial identifier.</value>
        public int EditorialId { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; }

        /// <summary>
        /// Gets the sypnosis.
        /// </summary>
        /// <value>The sypnosis.</value>
        public string Sypnosis { get; }

        /// <summary>
        /// Gets the number pages.
        /// </summary>
        /// <value>The number pages.</value>
        public string NumberPages { get; }

        /// <summary>
        /// Gets the authors has books.
        /// </summary>
        /// <value>The authors has books.</value>
 
        public ICollection<AuthorHasBook> AuthorsHasBooks { get;  set; }

        /// <summary>
        /// Gets the editorial.
        /// </summary>
        /// <value>The editorial.</value>
        public   Editorial Editorial { get; set; }

        /// <summary>
        /// Adds the authors.
        /// </summary>
        /// <param name="authors">The authors.</param>
        public void AddAuthors(params Author[] authors)
        {
            var authorList = new List<AuthorHasBook>();
            authors.Aggregate(authorList, (current, author) =>
            {
                current.Add(new AuthorHasBook(author, Isbn));
                return authorList;
            });

            AuthorsHasBooks = authorList;
        }
    }
}
