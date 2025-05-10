using Booking.Models;

namespace Booking.Services
{
    public interface IEventService
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(string id);
        Task AddEventAsync(Event _event);
        Task UpdateEventAsync(Event _event);
        Task DeleteEventAsync(string id);
        Task<List<Event>> GetEventsByCategoryAsync(string category);
    }
}
