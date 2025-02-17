using System.ComponentModel.DataAnnotations;

namespace Event-Management-Web-App.Models
{
    public class Event
    {

        public int EventId { get; set; }

        [Required(ErrorMessage = "Event title is required")]
        public string EventTitle { get; set; }

        [Required(ErrorMessage = "Event description is required")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Event start date is required")]
        public DateTime EventStartDate { get; set; }

        public DateTime? EventEndDate { get; set; }

        [Required(ErrorMessage = "Event location is required")]
        public string EventLocation { get; set; }

        [Required(ErrorMessage = "Maximum attendees is required")]
        public int EventMaxAttendees { get; set; }

        public int EventRegistrations { get; set; } = 0;

        public List<Attendee> Attendees { get; set; } 
    }
}
