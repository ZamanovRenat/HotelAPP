using System.Collections.Generic;
using HotelAPP.Domain.Entities;

namespace HotelAPP.Services.Interfaces
{
    public interface IRoomsData
    {
        IEnumerable<Room> getAllRooms();
        Room getRoom(int id);
        int Add(Room room);
        void Update(Room room);
        bool Delete(int id);

    }
}
