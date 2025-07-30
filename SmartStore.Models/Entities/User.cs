
using Microsoft.AspNetCore.Identity;
namespace SmartStore.Models.Entities
{
    public class User: IdentityUser
    {
        public User() { }

        public string FirstName { get; set; }
        public string LastName { get; set; } = default!;

        public string City { get; set; } = default!;

    }
}
