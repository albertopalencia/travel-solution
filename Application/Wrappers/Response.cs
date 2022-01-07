﻿// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Response.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Collections.Generic;

namespace Application.Wrappers
{
    /// <summary>
    /// Class Response.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Response<T>
    {
        public Response()
        {
            
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="message">The message.</param>
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Response{T}"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public Response(string message )
        {
            Succeeded = false;
            Message = message;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Response{T}"/> is succeeded.
        /// </summary>
        /// <value><c>true</c> if succeeded; otherwise, <c>false</c>.</value>
        public bool Succeeded { get; set; }
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>The errors.</value>
        public List<string> Errors { get; set; }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        /// <value>The data.</value>
        public T Data { get; set; }
    }
}