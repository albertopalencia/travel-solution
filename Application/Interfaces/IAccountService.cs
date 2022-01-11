// Alberto Segundo Palencia Benedetty

using System.Threading.Tasks;
using Application.DTOs;
using Application.Wrappers;

namespace Application.Interfaces
{
    public interface IAccountService
    {
        Task<Response<AuthenticationResponseDto>> AuthenticateAsync(AuthenticationRequest request, string ipAddress);
        Task<Response<string>> RegisterAsync(RegisterRequest request, string origin);
    }
}