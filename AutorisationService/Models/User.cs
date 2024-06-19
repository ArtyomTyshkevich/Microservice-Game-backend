using Microsoft.AspNetCore.Identity;

namespace AutorisationService.Models
{
    public class User : IdentityUser<long>
    {
        public string? RefreshToken {  get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
