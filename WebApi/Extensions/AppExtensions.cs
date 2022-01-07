// ***********************************************************************
// Assembly         : WebApi
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="AppExtensions.cs" company="WebApi">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Microsoft.AspNetCore.Builder;
using WebApi.Middlewares;

namespace WebApi.Extensions
{
    /// <summary>
    /// Class AppExtensions.
    /// </summary>
    public static class AppExtensions
    {
        /// <summary>
        /// Uses the error handling middelware.
        /// </summary>
        /// <param name="app">The application.</param>
        public static void UseErrorHandlingMiddelware(this IApplicationBuilder app)
        {
            app.UseMiddleware<ErrorHandlerMiddleware>();
        }
    }
}