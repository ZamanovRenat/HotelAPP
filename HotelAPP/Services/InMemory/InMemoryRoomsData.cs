using System;
using System.Collections.Generic;
using System.Linq;
using HotelAPP.Data;
using HotelAPP.Domain.Entities;
using HotelAPP.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace HotelAPP.Services.InMemory
{
    public class InMemoryRoomsData : IRoomsData
    {
        private readonly ILogger<InMemoryRoomsData> _logger;
        private int _currentMaxId;

        public InMemoryRoomsData(ILogger<InMemoryRoomsData> logger)
        {
            _logger = logger;
            _currentMaxId = TestData.Rooms.Max(i => i.Id);
        }

        public IEnumerable<Room> getAllRooms() => TestData.Rooms;

        public Room getRoom(int id) => TestData.Rooms.SingleOrDefault(room => room.Id == id);

        public int Add(Room room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));

            if (TestData.Rooms.Contains(room)) return room.Id; // характерно только если inMemory!!!! Для БД не нужно!

            room.Id = ++_currentMaxId;
            TestData.Rooms.Add(room);

            _logger.LogInformation("Комната id:{0} добавлена", room.Id);

            return room.Id;
        }

        public void Update(Room room)
        {
            if (room is null) throw new ArgumentNullException(nameof(room));

            if (TestData.Rooms.Contains(room)) return; // Тоже только для реализации на List<T>... Для БД не нужно!

            var db_item = getRoom(room.Id);
            if (db_item is null) return;

            db_item.Name = room.Name;
            db_item.Capacity = room.Capacity;
            db_item.Comfort = room.Comfort;
            db_item.Price = room.Price;
            db_item.ImageUrl = room.ImageUrl;
            db_item.Image = room.Image;

            _logger.LogInformation("Карточка комнаты id:{0} отредактирована", room.Id);
        }

        public bool Delete(int id)
        {
            var db_item = getRoom(id);
            if (db_item is null)
            {
                _logger.LogWarning("При удалении сотрудник id:{0} не найден", id);
                return false;
            }

            var result = TestData.Rooms.Remove(db_item);

            if (result)
                _logger.LogInformation("Комната id:{0} удалёна", id);
            else
                _logger.LogError("При удалении комнаты id:{0} не найден", id);

            return result;
        }
    }
}
