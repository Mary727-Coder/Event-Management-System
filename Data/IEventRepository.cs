using Event-Management-Web-App.Models;

namespace Event-Management-Web-App.Data
{
    public interface IEventRepository
    {
        IEnumerable<Attendee> GetAllAttendeeWithEventDetails();
        IEnumerable<Event> GetAllUpComingEvents();
        Event GetEventById(int eventId);
        void AddAttendee(Attendee attendee);
        Event GetEventWithAttendees(int eventId);
        void SaveChanges();
        
    }
}


