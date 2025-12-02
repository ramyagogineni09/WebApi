using Microsoft.AspNetCore.Identity;

namespace Webapi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
    }
}
