using Booking.Models;
using Booking.Repositories;

namespace Booking.Services
{
    public class EventService : IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<List<Event>> GetAllEventsAsync()
        {
            return await _eventRepository.GetAllEventsAsync();
        }
        public async Task<Event> GetEventByIdAsync(string id)
        {
            return await _eventRepository.GetEventByIdAsync(id);
        }
        public async Task AddEventAsync(Event _event)
        {
            await _eventRepository.AddEventAsync(_event);
        }
        public async Task UpdateEventAsync(Event _event)
        {
            await _eventRepository.UpdateEventAsync(_event);
        }
        public async Task DeleteEventAsync(string id)
        {
            await _eventRepository.DeleteEventAsync(id);
        }
        public async Task<List<Event>> GetEventsByCategoryAsync(string category)
        {
            return await _eventRepository.GetEventsByCategoryAsync(category);
        }
    }
}
