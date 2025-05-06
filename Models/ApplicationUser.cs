using Microsoft.AspNetCore.Identity;

namespace Booking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserEvent> UserEvents { get; set; }
    }
}
