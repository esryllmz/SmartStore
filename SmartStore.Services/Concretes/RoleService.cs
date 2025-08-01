using Microsoft.AspNetCore.Identity;
using SmartStore.Core.Exceptions;
using SmartStore.Core.Utils;
using SmartStore.Models.Dtos.Users.Requests;
using SmartStore.Models.Entities;
using SmartStore.Services.Abstracts;
using SmartStore.Services.Rules;

namespace SmartStore.Services.Concretes
{
    public class RoleService(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, RoleBusinessRules _businessRules) : IRoleService
    {
        public async Task<string> AddRoleAsync(string name)
        {
            await _businessRules.IsRoleUniqueAsync(name);

            var role = new IdentityRole()
            {
                Name = name
            };

            var result = await _roleManager.CreateAsync(role);
            IdentityResultHelper.Check(result);

            return $"{name} isimli rol eklendi.";
        }

        public async Task<string> AddRoleToUser(AddRoleToUserRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            _businessRules.EnsureRoleExists(role);

            var user = await _userManager.FindByIdAsync(request.UserId);
            _businessRules.EnsureUserExists(user);

            var addRoleToUser = await _userManager.AddToRoleAsync(user, request.RoleName);
            IdentityResultHelper.Check(addRoleToUser);

            return $"Kullanıcıya {request.RoleName} isimli rol eklendi.";
        }

        public async Task<List<string>> GetAllRolesByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            _businessRules.EnsureUserExists(user);

            var roles = await _userManager.GetRolesAsync(user);

            return roles.ToList();
        }
    }
}
