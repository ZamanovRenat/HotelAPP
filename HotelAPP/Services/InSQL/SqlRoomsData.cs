using System;
using System.Collections.Generic;
using System.Linq;
using HotelAPP.Context;
using HotelAPP.Data;
using HotelAPP.Domain.Entities;
using HotelAPP.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelAPP.Services.InSQL
{
    public class SqlRoomsData : IRoomsData
    {
        private readonly HotelContext _db;

        public SqlRoomsData(HotelContext db) => _db = db;

        public IEnumerable<Room> getAllRooms() => _db.Rooms.ToArray();

        public Room getRoom(int id) => _db.Rooms.SingleOrDefault(room => room.Id == id);

        public int Add(Room room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));
            _db.Rooms.Add(room);
            _db.Entry(room).State = EntityState.Added;
            _db.Add(room);
            _db.SaveChanges();
            return room.Id;
        }

        public void Update(Room room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));

            _db.Update(room);

            _db.SaveChanges();
        }

        public bool Delete(int id)
        {
            var room = _db.Rooms
            .Select(e => new Room() { Id = e.Id })
            .FirstOrDefault(e => e.Id == id);
            if (room is null) return false;

            _db.Remove(room);

            _db.SaveChanges();

            return true;
        }
    }
}
