// ***********************************************************************
// Assembly         : Persistence
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="ApplicationDbContext.cs" company="Persistence">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Contexts
{
    /// <summary>
    /// Class ApplicationDbContext.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.DbContext" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public sealed class ApplicationDbContext : DbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationDbContext" /> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
          //  ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
           // ChangeTracker.LazyLoadingEnabled = true;
        }

        /// <summary>
        /// Gets or sets the authors.
        /// </summary>
        /// <value>The authors.</value>
        public DbSet<Author> Authors { get; set; }
        /// <summary>
        /// Gets or sets the books.
        /// </summary>
        /// <value>The books.</value>
        public DbSet<Book> Books { get; set; }
        /// <summary>
        /// Gets or sets the editorials.
        /// </summary>
        /// <value>The editorials.</value>
        public DbSet<Editorial> Editorials { get; set; }

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention from the entity types
        /// exposed in <see cref="T:Microsoft.EntityFrameworkCore.DbSet`1" /> properties on your derived context. The resulting model may be cached
        /// and re-used for subsequent instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder">The builder being used to construct the model for this context. Databases (and other extensions) typically
        /// define extension methods on this object that allow you to configure aspects of the model that are specific
        /// to a given database.</param>
        /// <remarks>If a model is explicitly set on the options for this context (via <see cref="M:Microsoft.EntityFrameworkCore.DbContextOptionsBuilder.UseModel(Microsoft.EntityFrameworkCore.Metadata.IModel)" />)
        /// then this method will not be run.</remarks>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}