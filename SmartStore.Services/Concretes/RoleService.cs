using Microsoft.AspNetCore.Identity;
using SmartStore.Core.Exceptions;
using SmartStore.Models.Dtos.Users.Requests;
using SmartStore.Models.Entities;
using SmartStore.Services.Abstracts;
using SmartStore.Services.Rules;

namespace SmartStore.Services.Concretes
{
    public class RoleService(UserManager<User> _userManager, RoleManager<IdentityRole> _roleManager, RoleBusinessRules _roleBusinessRules) : IRoleService
    {
        public async Task<string> AddRoleAsync(string name)
        {
            await _roleBusinessRules.IsRoleUniqueAsync(name);
            var role = new IdentityRole()
            {
                Name = name
            };

            var result= await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
            {
                throw new BusinessException("Rol eklenirken bir hata oluştu.");
            }

            return $"{name} isimli rol eklendi.";

        }

        public async Task<string> AddRoleToUser(AddRoleToUserRequest request)
        {
            var role = await _roleManager.FindByNameAsync(request.RoleName);
            _roleBusinessRules.EnsureRoleExists(role);

            var user = await _userManager.FindByIdAsync(request.UserId);
            _roleBusinessRules.EnsureUserExists(user);

            var result = await _userManager.AddToRoleAsync(user, request.RoleName);
            if (!result.Succeeded)
            {
                throw new BusinessException("Kullanıcıya rol eklenirken bir hata oluştu.");
            }
            return ($"{user.UserName} kullanıcısına {request.RoleName} rolü eklendi.");

        }

        public async Task<List<string>> GetAllRolesByUserId(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            _roleBusinessRules.EnsureUserExists(user);

            var roles =await  _userManager.GetRolesAsync(user);
            return roles.ToList();

        }
    }
}
