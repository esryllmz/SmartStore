using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using SmartStore.Core.Exceptions;
using SmartStore.Models.Entities;

namespace SmartStore.Services.Rules
{
    public class RoleBusinessRules
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleBusinessRules(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public void EnsureRoleExists(IdentityRole role)
        {
            if(role == null)
            {
                throw new NotFoundException("Role cannot be null.");
            }
        }
        public void EnsureUserExists(User user)
        {
            if (user == null)
            {
                throw new NotFoundException("User cannot be null.");
            }
        }

        public async Task IsRoleUniqueAsync(string roleName)
        {
            var role= await _roleManager.FindByNameAsync(roleName);

            if (role != null)
            {
                throw new BusinessException($"Role with name '{role}' already exists.");
            }
        }



    }
}
