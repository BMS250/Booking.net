using System.ComponentModel.DataAnnotations;

namespace Booking.Models
{
    public class Event
    {
        public string Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        [Required, MaxLength(255)]
        public string Description { get; set; }

        [Required, MaxLength(30)]
        public string Category { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required, MaxLength(100)]
        public string Venue { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public List<UserEvent> UserEvents { get; set; }
    }
}
