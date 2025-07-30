using SmartStore.Models.Dtos.Users.Requests;

namespace SmartStore.Services.Abstracts;

public interface IRoleService
{
    Task<string> AddRoleToUser(AddRoleToUserRequest request);

    Task<List<string>> GetAllRolesByUserId(string userId);

    Task<string> AddRoleAsync(string name);
}
