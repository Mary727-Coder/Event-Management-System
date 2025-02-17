using Event-Management-Web-App.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Event-Management-Web-App.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Events.Any())
            {
                context.Events.AddRange(
                  new Event
                  {
                      EventTitle = "Soweto Fashion Week",
                      EventDescription = "Soweto Fashion Week showcases global talent.",
                      EventStartDate = new DateTime(2024, 5, 1),
                      EventEndDate = new DateTime(2024, 5, 4),
                      EventLocation = "Soweto,Johannesburg",
                      EventMaxAttendees = 450,
                      EventRegistrations = 0
                  },
                new Event
                {
                    EventTitle = "Rise Up Conference 2024",
                    EventDescription = "Join us for worship, community building, and empowerment.",
                    EventLocation = "Cornerstone Church, Bedfordview",
                    EventStartDate = new DateTime(2024, 6, 20),
                    EventEndDate = new DateTime(2024, 6, 22),
                    EventMaxAttendees = 500,
                    EventRegistrations = 0
                },
                new Event
                {
                    EventTitle = "TECHSPO Johannesburg Technology Expo",
                    EventDescription = "Showcast latest advances in technology.",
                    EventLocation = "Sandton,Johannesburg",
                    EventStartDate = new DateTime(2024, 6, 8),
                    EventMaxAttendees = 1, // Only one attendee allowed
                    EventRegistrations = 0
                }
            );
                context.SaveChanges();
            }
        }
    }
}

