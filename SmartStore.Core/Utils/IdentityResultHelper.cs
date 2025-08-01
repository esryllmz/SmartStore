using Microsoft.AspNetCore.Identity;
using SmartStore.Core.Exceptions;

namespace SmartStore.Core.Utils;

public static class IdentityResultHelper
{
    public static void Check(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }
    }
}
