using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelAPP.Domain.Entities;

namespace HotelAPP.Data
{
    public class TestData
    {
        public static List<Room> Rooms { get; } = new()
        {
            new Room()
            {
                Name = "Luxe",
                Capacity = 2,
                Comfort = "Luxe",
                ImageUrl = "Room1.jpg",
                Price = 1050
            },
            new Room()
            {
                Name = "HalfLuxe",
                Capacity = 2,
                Comfort = "HalfLuxe",
                ImageUrl = "Room2.jpg",
                Price = 1050
            },
            new Room()
            {
                Name = "Ordinary",
                Capacity = 2,
                Comfort = "Ordinary",
                ImageUrl = "Room3.jpg",
                Price = 1050
            }
        };
    }
}
