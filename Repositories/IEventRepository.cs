using Booking.Models;

namespace Booking.Repositories
{
    public interface IEventRepository
    {
        Task<List<Event>> GetAllEventsAsync();
        Task<Event> GetEventByIdAsync(string id);
        Task AddEventAsync(Event _event);
        Task UpdateEventAsync(Event _event);
        Task DeleteEventAsync(string id);
        Task<List<Event>> GetEventsByCategoryAsync(string category);
    }
}
