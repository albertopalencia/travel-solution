// ***********************************************************************
// Assembly         : Application
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="GeneralSpecification.cs" company="Application">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using Ardalis.Specification;

namespace Application.Specifications
{
    /// <summary>
    /// Class GeneralSpecification.
    /// Implements the <see cref="Ardalis.Specification.Specification{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Ardalis.Specification.Specification{T}" />
    public class GeneralSpecification<T> : Specification<T>, ISingleResultSpecification
    {
        
    }
}