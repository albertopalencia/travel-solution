// Alberto Segundo Palencia Benedetty

using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using MediatR;

namespace Application.Feautures.Authenticate.Commands.AuthenticateCommand
{
    public class AuthenticateCommand : IRequest<Response<AuthenticationResponseDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }

        public class  AuthenticateCommandHandler: IRequestHandler<AuthenticateCommand, Response<AuthenticationResponseDto>>
        {
            private readonly IAccountService _accountService;

            public AuthenticateCommandHandler(IAccountService accountService)
            {
                _accountService = accountService;
            }

            public async Task<Response<AuthenticationResponseDto>> Handle(AuthenticateCommand request, CancellationToken cancellationToken)
            {
                return await _accountService.AuthenticateAsync(new AuthenticationRequest
                {
                    Email = request.Email,
                    Password = request.Password
                }, request.IpAddress);
            }
        }
    }
}