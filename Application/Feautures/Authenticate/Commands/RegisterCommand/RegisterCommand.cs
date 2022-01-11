﻿// Alberto Segundo Palencia Benedetty

using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Feautures.Authenticate.Commands.RegisterCommand
{
    public class RegisterCommand : IRequest<Response<string>>
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Origin { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Response<string>>
        {
            private readonly IAccountService _accountService;

            public RegisterCommandHandler(IAccountService accountService)
            {
                _accountService = accountService;
            }

            public async Task<Response<string>> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                return await _accountService.RegisterAsync(new RegisterRequest
                {
                    Email = request.Email,
                    UserName = request.UserName,
                    Password = request.Password,
                    ConfirmPassword = request.ConfirmPassword,
                    Nombre = request.Nombre,
                    Apellido = request.Apellido
                }, request.Origin);
            }
        }
    }
}