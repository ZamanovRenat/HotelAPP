﻿using HotelAPP.Domain.Entities;
using HotelAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPP.Context
{
    public class HotelContext : DbContext
    {
        public DbSet<Booking> Checkins { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        //public DbSet<RegisterClientViewModel> RegisterUsers { get; set; }

        public HotelContext(DbContextOptions<HotelContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
