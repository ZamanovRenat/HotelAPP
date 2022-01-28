using Microsoft.AspNetCore.Identity;

namespace HotelAPP.Domain.Entities.Identity
{
    public class User : IdentityUser
    {
        public const string Administrator = "Admin";

        public const string DefaultAdminPassword = "AdPAss_123";
    }
}
