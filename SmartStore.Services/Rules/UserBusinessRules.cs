using Microsoft.AspNetCore.Identity;
using SmartStore.Core.Exceptions;
using SmartStore.Models.Entities;

namespace SmartStore.Services.Rules;

public class UserBusinessRules(UserManager<User> _userManager)
{
    public async Task<User> EnsureUserExistsAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            throw new NotFoundException("User cannot be null.");
        }

        return user;
    }

    public async Task<User> EnsureUserExistsByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            throw new AuthorizationException("Your login information is incorrect.");
        }

        return user;
    }

    public async Task<User> EnsureUserExistsByUsernameAsync(string username)
    {
        var user = await _userManager.FindByNameAsync(username);

        if (user == null)
        {
            throw new NotFoundException("User not found.");
        }

        return user;
    }

    public async Task CheckUserPasswordAsync(User user, string password)
    {
        bool checkPassword = await _userManager.CheckPasswordAsync(user, password);

        if (!checkPassword)
        {
            throw new AuthorizationException("Your login information is incorrect.");
        }
    }

    public void EnsurePasswordsMatch(string newPassword, string confirmNewPassword)
    {
        if (!newPassword.Equals(confirmNewPassword))
        {
            throw new BusinessException("Passwords do not match.");
        }
    }

    public async Task IsUsernameUniqueAsync(string username)
    {
        var existingUser = await _userManager.FindByNameAsync(username);

        if (existingUser != null)
        {
            throw new BusinessException($"The username {username} is already taken.");
        }
    }
}
