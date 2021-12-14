using System.Linq;
using HotelAPP.Context;
using HotelAPP.Models;

namespace HotelAPP.Data
{
    public class HotelDBInitializer
    {
        public static void Initialize(HotelContext context)
        {
            if (!context.Rooms.Any())
            {
                context.Rooms.AddRange(
                    new Room()
                    {
                        Id = 1,
                        Capacity = 2,
                        Comfort = "Luxe",
                        ImageUrl = "Room1.jpg",
                        Price = 1050
                    },
                    new Room()
                    {
                        Id = 2,
                        Capacity = 2,
                        Comfort = "HalfLuxe",
                        ImageUrl = "Room2.jpg",
                        Price = 1050
                    },
                    new Room()
                    {
                        Id = 3,
                        Capacity = 2,
                        Comfort = "Ordinary",
                        ImageUrl = "Room3.jpg",
                        Price = 1050
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
