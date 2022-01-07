// ***********************************************************************
// Assembly         : Persistence
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="ApplicationDbContextModelSnapshot.cs" company="Persistence">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Persistence.Contexts;

namespace Persistence.Migrations
{
    /// <summary>
    /// Class ApplicationDbContextModelSnapshot.
    /// Implements the <see cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot" />
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        /// <summary>
        /// Called lazily by <see cref="P:Microsoft.EntityFrameworkCore.Infrastructure.ModelSnapshot.Model" /> to build the model snapshot
        /// the first time it is requested.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="T:Microsoft.EntityFrameworkCore.ModelBuilder" /> to use to build the model.</param>
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Apellidos");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Domain.Entities.AuthorHasBook", b =>
                {
                    b.Property<int>("AuthorId")
                        .HasColumnType("int")
                        .HasColumnName("Autores_Id");

                    b.Property<int>("BookIsbn")
                        .HasColumnType("int")
                        .HasColumnName("Libros_ISBN");

                    b.HasKey("AuthorId", "BookIsbn");

                    b.HasIndex("BookIsbn");

                    b.ToTable("AuthorHasBook");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Property<int>("Isbn")
                        .HasMaxLength(13)
                        .HasColumnType("int")
                        .HasColumnName("ISBN");

                    b.Property<int>("EditorialId")
                        .HasMaxLength(13)
                        .HasColumnType("int")
                        .HasColumnName("editoriales_id");

                    b.Property<string>("NumberPages")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("n_paginas");

                    b.Property<string>("Sypnosis")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("nvarchar(4000)")
                        .HasColumnName("sinopsis");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("titulo");

                    b.HasKey("Isbn");

                    b.HasIndex("EditorialId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Domain.Entities.Editorial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(10)
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Campus")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Sede");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("nvarchar(45)")
                        .HasColumnName("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Editorials");
                });

            modelBuilder.Entity("Domain.Entities.AuthorHasBook", b =>
                {
                    b.HasOne("Domain.Entities.Author", "Author")
                        .WithMany("AuthorsHasBooks")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Book", "Book")
                        .WithMany("AuthorsHasBooks")
                        .HasForeignKey("BookIsbn")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.HasOne("Domain.Entities.Editorial", "Editorial")
                        .WithMany()
                        .HasForeignKey("EditorialId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Editorial");
                });

            modelBuilder.Entity("Domain.Entities.Author", b =>
                {
                    b.Navigation("AuthorsHasBooks");
                });

            modelBuilder.Entity("Domain.Entities.Book", b =>
                {
                    b.Navigation("AuthorsHasBooks");
                });
#pragma warning restore 612, 618
        }
    }
}
