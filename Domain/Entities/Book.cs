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

namespace Domain.Entities
{
    /// <summary>
    /// Class Book.
    /// </summary>
    public class Book
    {
        
        public Book()
        {
            
        }

        public Book(int idEditorial, string title, string sypnosis, string numberPages, int isbn, params Author[] authors)
        {
            EditorialId = idEditorial;
            Title = title;
            Sypnosis = sypnosis;
            NumberPages = numberPages;
            Isbn = isbn;
            AddAuthors(authors);
        }


        /// <summary>
        /// Gets the isbn.
        /// </summary>
        /// <value>The isbn.</value>
        [DatabaseGenerated(DatabaseGeneratedOption.None)] 
        public int Isbn { get; set; }

        /// <summary>
        /// Gets the editorial identifier.
        /// </summary>
        /// <value>The editorial identifier.</value>
        public int EditorialId { get; set; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Gets the sypnosis.
        /// </summary>
        /// <value>The sypnosis.</value>
        public string Sypnosis { get; set; }

        /// <summary>
        /// Gets the number pages.
        /// </summary>
        /// <value>The number pages.</value>
        public string NumberPages { get; set; }

        /// <summary>
        /// Gets the authors has books.
        /// </summary>
        /// <value>The authors has books.</value>
 
        public virtual ICollection<AuthorHasBook> AuthorsHasBooks { get;  set; }
         

        public void AddAuthors(params Author[] authors)
        {
            var authorsForBooks = new List<AuthorHasBook>();
            authors.Aggregate(authorsForBooks, (current, author) =>
            {
                current.Add(new AuthorHasBook(author, Isbn));
                return authorsForBooks;
            });

            AuthorsHasBooks = authorsForBooks;

        }
    }
}
