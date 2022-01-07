// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="CreateAuthorCommandValidator.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using FluentValidation;

namespace Application.Feautures.Author.Commands.CreateAuthorCommand
{
    /// <summary>
    /// Class CreateAuthorCommandValidator.
    /// Implements the <see cref="FluentValidation.AbstractValidator{CreateAuthorCommand}" />
    /// </summary>
    /// <seealso cref="FluentValidation.AbstractValidator{CreateAuthorCommand}" />
    public class CreateAuthorCommandValidator: AbstractValidator<CreateAuthorCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateAuthorCommandValidator"/> class.
        /// </summary>
        public CreateAuthorCommandValidator()
        {
            RuleFor(it => it.Name)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(45).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");

            RuleFor(it => it.LastName)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacio")
                .MaximumLength(45).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres");
        }
    }
}