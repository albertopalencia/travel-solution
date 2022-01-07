// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="ServiceExtensions.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Application.Behaviours;
using FluentValidation;
using MediatR;

namespace Application
{
    /// <summary>
    /// Class ServiceExtensions.
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Adds the aplication layer.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void AddAplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}
