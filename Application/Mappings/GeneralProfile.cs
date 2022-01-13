// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="GeneralProfile.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Application.DTOs;
using Application.Feautures.Author.Commands.CreateAuthorCommand;
using Application.Feautures.Book.Commands.CreateBookCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    /// <summary>
    /// Class GeneralProfile.
    /// Implements the <see cref="AutoMapper.Profile" />
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class GeneralProfile: Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralProfile"/> class.
        /// </summary>
        public GeneralProfile()
        {
            #region Dtos

            CreateMap<Author, AuthorDto>();

            CreateMap<Book, BookDto>().ReverseMap();

            CreateMap<Editorial, EditorialDto>().ReverseMap();
            #endregion

            #region Commands

            CreateMap<CreateAuthorCommand, Author>();

            CreateMap<CreateBookCommand, Book>();

            #endregion
        }
    }
}