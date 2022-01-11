// ***********************************************************************
// Assembly         : Identity
// Author           : alberto palencia
// Created          : 01-07-2022
//
// Last Modified By : alberto palencia
// Last Modified On : 01-07-2022
// ***********************************************************************
// <copyright file="DefaultBasicUser.cs" company="Identity">
//     Copyright (c) everis. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System.Linq;
using System.Threading.Tasks;
using Application.Enums;
using Identity.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity.Seeds
{
    /// <summary>
    /// Class DefaultBasicUser.
    /// </summary>
    public class DefaultBasicUser
    {

        /// <summary>
        /// seed as an asynchronous operation.
        /// </summary>
        /// <param name="userManager">The user manager.</param>
        /// <param name="roleManager">The role manager.</param>
        /// <returns>Task.</returns>
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "userABasic",
                Email = "userBasic@gmail.com",
                FirtsName = "Josue",
                LastName = "Palencia",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };
            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user is null)
                {
                    await userManager.CreateAsync(defaultUser, "123Pa$word");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
                }
            }
        }
    }
}