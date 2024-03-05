using Microsoft.AspNetCore.Identity;

namespace Backend.Entities
{
    public class CustomUser:IdentityUser
    {
        public string Fullname { get; set; } = null!;
    }
}
