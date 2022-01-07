// ***********************************************************************
// Assembly         : Persistence
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="AuthorHasBookConfiguration.cs" company="Persistence">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    /// <summary>
    /// Class AuthorHasBookConfiguration.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AuthorHasBook}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{AuthorHasBook}" />
    public class AuthorHasBookConfiguration: IEntityTypeConfiguration<AuthorHasBook>
    { 
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<AuthorHasBook> builder)
        {
            builder.HasKey(it => new { it.AuthorId, it.BookIsbn });

            builder.HasOne(b => b.Book)
                .WithMany(c => c.AuthorsHasBooks)
                .HasForeignKey(f => f.BookIsbn);

            builder.HasOne(b => b.Author)
                .WithMany(c => c.AuthorsHasBooks)
                .HasForeignKey(f => f.AuthorId);
        }
        
    }
}
