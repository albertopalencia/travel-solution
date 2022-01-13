// ***********************************************************************
// Assembly         : Domain
// Author           : alberto palencia
// Created          : 01-06-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-06-2022
// ***********************************************************************
// <copyright file="Editorial.cs" company="Domain">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Domain.Entities
{
    /// <summary>
    /// Class Editorial.
    /// </summary>
    public class Editorial
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Editorial"/> class.
        /// </summary>
        public Editorial()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Editorial" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="campus">The campus.</param>
        /// <param name="id">The identifier.</param>
        public Editorial(string name, string campus, int? id = null)
        {
            Name = name;
            Campus = campus;
            Id = id ?? 0;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name { get; }

        /// <summary>
        /// Gets the campus.
        /// </summary>
        /// <value>The campus.</value>
        public string Campus { get; }
    }
}
