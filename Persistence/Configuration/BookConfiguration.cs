// ***********************************************************************
// Assembly         : Persistence
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="BookConfiguration.cs" company="Persistence">
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
    /// Class BookConfiguration.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Book}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Book}" />
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.Property(it => it.Isbn)
                .HasColumnName("ISBN")
                .HasMaxLength(13);

            builder.HasKey(it => it.Isbn);

            builder.Property(it => it.EditorialId)
                .HasColumnName("editoriales_id")
                .IsRequired()
                .HasMaxLength(13);

            builder.Property(it => it.Title)
                .HasColumnName("titulo")
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(it => it.Sypnosis)
                .HasColumnName("sinopsis")
                .IsRequired()
                .HasMaxLength(4000);
            builder.Property(it => it.NumberPages)
                .HasColumnName("n_paginas")
                .IsRequired()
                .HasMaxLength(45);

        }
    }
}
