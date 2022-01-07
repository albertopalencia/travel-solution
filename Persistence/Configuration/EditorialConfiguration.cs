// ***********************************************************************
// Assembly         : Persistence
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="EditorialConfiguration.cs" company="Persistence">
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
    /// Class EditorialConfiguration.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Editorial}" />
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Editorial}" />
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Domain.Entities.Editorial}" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Domain.Entities.Editorial}" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Editorial}" />
    /// <seealso cref="Microsoft.EntityFrameworkCore.IEntityTypeConfiguration{Editorial}" />
    public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
    {
        /// <summary>
        /// Configures the entity of type <typeparamref name="TEntity" />.
        /// </summary>
        /// <param name="builder">The builder to be used to configure the entity type.</param>
        public void Configure(EntityTypeBuilder<Editorial> builder)
        {
            builder.HasKey(it => it.Id);
            builder.Property(it => it.Id)
                .HasMaxLength(10);
            builder.Property(it => it.Name)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(45);
            builder.Property(it => it.Campus)
                .HasColumnName("Sede")
                .IsRequired()
                .HasMaxLength(45);
        }
    }
}
