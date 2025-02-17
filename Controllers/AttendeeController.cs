using Event-Management-Web-App.Data;
using Event-Management-Web-App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Event-Management-Web-App.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public AttendeeController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
       
        public IActionResult Register(int eventId, string Name, string Email)
        {
            var attendee = new Attendee
            {
                EventId = eventId,
                AttendeeName = Name,
                AttendeeEmail = Email

            };
            return View(attendee);
        }

        [HttpPost]
        public IActionResult Register(int eventId, Attendee attendee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var @event = _eventRepository.GetEventById(eventId);
                    if (@event != null)
                    {
                        int availableSpots = @event.EventMaxAttendees - @event.EventRegistrations;
                        if (availableSpots > 0)
                        {
                            _eventRepository.AddAttendee(attendee);
                            @event.EventRegistrations++;
                            _eventRepository.SaveChanges();

                            return RedirectToAction("Confirmation","Attendee", new { eventId });
                        }
                    }
                }
                return View(attendee);
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Unable to save changes. Please try again.");
                return View(attendee);
            }
        }

        public IActionResult Confirmation(int eventId)
        {
 
            var @event = _eventRepository.GetEventWithAttendees(eventId);
           
            return View(@event);
        }
    }
}

