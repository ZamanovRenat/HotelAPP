using Microsoft.AspNetCore.Identity;

namespace HotelAPP.Domain.Entities.Identity
{
    public class Role : IdentityRole
    {
        public const string Administrators = "Administrators";

        public const string Users = "Users";
    }
}
