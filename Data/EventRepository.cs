using Event-Management-Web-App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Event-Management-Web-App.Data
{
    public class EventRepository : IEventRepository
    {
        private readonly AppDbContext _appDbContext;

        public EventRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Attendee> GetAllAttendeeWithEventDetails()
        {
            return _appDbContext.Attendees.Include(a => a.Event); 

        }

        public IEnumerable<Event> GetAllUpComingEvents()
        {
            return _appDbContext.Events.OrderBy(e => e.EventStartDate).ToList();
        }

        public Event GetEventById(int eventId)
        {
            return _appDbContext.Events.FirstOrDefault(e => e.EventId == eventId);
        }

        public void AddAttendee(Attendee attendee)
        {
            _appDbContext.Attendees.Add(attendee);
        }
        public Event GetEventWithAttendees(int eventId)
        {
            return _appDbContext.Events.Where(e => e.EventId == eventId).Include(e => e.Attendees).FirstOrDefault();
        }
     
        public void SaveChanges()
        {
            _appDbContext.SaveChanges();
        }

    }
}
