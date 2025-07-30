using SmartStore.Models.Dtos.Tokens.Responses;
using SmartStore.Models.Entities;

namespace SmartStore.Services.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateJwtTokenAsync(User user);
}
