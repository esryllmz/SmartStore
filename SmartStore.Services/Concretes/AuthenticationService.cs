using SmartStore.Core.Responses;
using SmartStore.Models.Dtos.Tokens.Responses;
using SmartStore.Models.Dtos.Users.Requests;
using SmartStore.Services.Abstracts;

namespace SmartStore.Services.Concretes
{
    public class AuthenticationService(IUserService _userService, IJwtService _jwtService) : IAuthenticationService
    {
        public async Task<ReturnModel<TokenResponseDto>> LoginAsync(LoginRequest request)
        {
            var user = await _userService.LoginAsync(request);
            var tokenResponse= await _jwtService.CreateJwtTokenAsync(user);
            return new ReturnModel<TokenResponseDto>
            {
                Data =tokenResponse,
                Success = true,
                Message = "Login successful",
                StatusCode = 200 
            };
        }

        public async Task<ReturnModel<TokenResponseDto>> RegisterAsync(RegisterRequest request)
        {
            var user = await _userService.RegisterAsync(request);
            var tokenResponse = await _jwtService.CreateJwtTokenAsync(user);

            return new ReturnModel<TokenResponseDto>
            {
                Data = tokenResponse,
                Success = true,
                Message = "Registration successful",
                StatusCode = 201
            };
        }
    }
}
