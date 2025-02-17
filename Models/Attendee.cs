using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Event-Management-Web-App.Models
{
    public class Attendee
    {
        public int AttendeeId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [DisplayName("Name")]
        public string AttendeeName { get; set; }

        [Required(ErrorMessage = "please enter your email address")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "please enter a valid email address")]
        [DisplayName("Email")]
        public string AttendeeEmail { get; set; }

        [Required]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
