using Microsoft.AspNetCore.Identity;

namespace Booking.Models
{
    public class ApplicationUser : IdentityUser
    {
        public virtual List<UserEvent> UserEvents { get; set; }
    }
}
