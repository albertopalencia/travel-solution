// Alberto Segundo Palencia Benedetty

using Application.DTOs;
using Application.Enums;
using Application.Exceptions;
using Application.Interfaces;
using Application.Wrappers;
using Domain.Settings;
using Identity.Helpers;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser>  _signInManager;
        private readonly JwtSettings _jwtSettings;

        public AccountService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IOptions<JwtSettings> jwtSettings)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Response<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null) throw new ApiException($"No hay una cuenta registrada con el email {request.Email}");

            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
            if (!result.Succeeded) throw new ApiException("Las credenciales del usuario no son validas");

            var jwtSecurityToken = await GenerateToken(user);
            var roleList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            var refreshToken = GenerateRefreshToken(ipAddress);
            
            var response = new AuthenticationResponseDto
            {
                Id = user.Id,
                JwToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                UserName = user.UserName,
                Roles = roleList.ToList(),
                IsVerified = user.EmailConfirmed,
                RefreshToken = refreshToken.Token
            };

            return new Response<AuthenticationResponseDto>(response, $"Usuario Autenticado {user.UserName}");
        }

        private RefreshTokenDto GenerateRefreshToken(string ipAddress)
        {
            return new RefreshTokenDto
            {
                Token = RandomTokenString(),
                Expires = DateTime.Now.AddDays(3),
                Created = DateTime.Now,
                CreatedByIp = ipAddress
            };
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private async Task<JwtSecurityToken> GenerateToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim("roles", role)).ToList();
            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("uid", user.Id),
                    new Claim("ip", IpHelper.GetIpAddress())
                }.Union(userClaims)
                .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var sigingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: sigingCredentials
                );
            return jwtSecurityToken;
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            var userNameExits = await _userManager.FindByNameAsync(request.UserName);
            if (userNameExits != null)
            {
                throw new ApiException($"El nombre de usuario {request.UserName} ya fue registrado previamente.");
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirtsName = request.Nombre,
                LastName = request.Apellido,
                UserName = request.UserName,
                EmailConfirmed = true
            };
            var userEmailExits = await _userManager.FindByEmailAsync(request.Email);
            if (userEmailExits != null)
            {
                throw new ApiException($"El email {request.UserName} ya fue registrado previamente.");
            }

            var result = await _userManager.CreateAsync(user, request.Password);
            if (!result.Succeeded) throw new ApiException($"{result.Errors}");

            await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
            return new Response<string>(user.Id, message: $"Usuario registrado exitosamente. {request.UserName}");
        }
    }
}