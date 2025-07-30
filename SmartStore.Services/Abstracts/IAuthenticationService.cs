using SmartStore.Core.Responses;
using SmartStore.Models.Dtos.Tokens.Responses;
using SmartStore.Models.Dtos.Users.Requests;

namespace SmartStore.Services.Abstracts
{
    public interface IAuthenticationService
    {
        Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequest request);
        Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequest request);
    }
}
