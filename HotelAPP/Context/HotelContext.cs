using HotelAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPP.Context
{
    public class HotelContext : DbContext
    {
        public DbSet<Checkin> Checkins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
