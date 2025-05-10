using Booking.Data;
using Booking.Models;
using Microsoft.EntityFrameworkCore;

namespace Booking.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly ApplicationDbContext _context;
        public EventRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Event>> GetAllEventsAsync()
        {
            return _context.Events.ToListAsync();
        }

        public Task<Event> GetEventByIdAsync(string id)
        {
            return _context.Events.FirstOrDefaultAsync(e => e.Id == id);
        }

        public ValueTask<Event?> GetEdventByIdAsync(string id)
        {
            return _context.Events.FindAsync(id);
        }

        public Task<List<Event>> GetEventsByCategoryAsync(string category)
        {
            return _context.Events
                .Where(e => e.Category == category)
                .ToListAsync();
        }

        public Task AddEventAsync(Event _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException(nameof(_event));
            }
            try
            {
                _context.Events.Add(_event);
                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public Task UpdateEventAsync(Event _event)
        {
            if (_event == null)
            {
                throw new ArgumentNullException(nameof(_event));
            }
            try
            {
                _context.Events.Update(_event);
                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteEventAsync(string id)
        {
            var _event = _context.Events.Find(id);
            if (_event == null)
            {
                throw new ArgumentNullException(nameof(_event));
            }
            try
            {
                _context.Events.Remove(_event);
                return _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
