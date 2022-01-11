// ***********************************************************************
// Assembly         : Identity
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="DefaultRoles.cs" company="Identity">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Threading.Tasks;
using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    /// <summary>
    /// Class DefaultRoles.
    /// </summary>
    public static class DefaultRoles
    {
        /// <summary>
        /// seed as an asynchronous operation.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <returns>Task.</returns>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Basic.ToString()));
        }
    }
}