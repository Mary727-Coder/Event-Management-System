using Event-Management-Web-App.Data;
using Event-Management-Web-App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Event-Management-Web-App.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;

        public EventController(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IActionResult Index( )
        {
            return View(_eventRepository.GetAllUpComingEvents()); 
        }

        public IActionResult Details(int eventId)
        {
            return View(_eventRepository.GetEventById(eventId));
        }      
    }
}
