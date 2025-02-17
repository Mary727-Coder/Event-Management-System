using Event-Management-Web-App.Models;
using Microsoft.EntityFrameworkCore;

namespace Event-Management-Web-App.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options) { }
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<Attendee>().ToTable("Attendee");

        }
    }
}
