using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelAPP.Domain.Entities;
using HotelAPP.Models;
using HotelAPP.Services.Interfaces;
using Microsoft.Extensions.Logging;

namespace HotelAPP.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomsData _roomsData;
        private readonly ILogger<Room> _logger;

        public RoomController(IRoomsData roomsData, ILogger<Room> logger)
        {
            _roomsData = roomsData;
            _logger = logger;
        }
        public IActionResult Index() => View();

        public IActionResult Details(int id)
        {
            var room = _roomsData.getRoom(id);

            if (room == null)
                return NotFound();

            return View(room);
        }

        public IActionResult Create() => View("Edit", new RoomViewModel());

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new RoomViewModel());

            var room = _roomsData.getRoom((int)id);
            if (room is null)
                return NotFound();

            var view_model = new RoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Comfort = room.Comfort,
                Price = room.Price,
                ImageUrl = room.ImageUrl,
                Image = room.Image,
            };

            return View(view_model);
        }
        [HttpPost]
        public IActionResult Edit(RoomViewModel model)
        {
            var room = new Room()
            {
                Id = model.Id,
                Name = model.Name,
                Capacity = model.Capacity,
                Comfort = model.Comfort,
                Price = model.Price,
                ImageUrl = model.ImageUrl,
                Image = model.Image,
            };

            if (room.Id == 0)
                _roomsData.Add(room);
            else
                _roomsData.Update(room);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            if (id <= 0) return BadRequest();

            var room = _roomsData.getRoom(id);
            if (room is null) return NotFound();

            return View(new RoomViewModel
            {
                Id = room.Id,
                Name = room.Name,
                Capacity = room.Capacity,
                Comfort = room.Comfort,
                Price = room.Price,
                ImageUrl = room.ImageUrl,
                Image = room.Image,
            });
        }
        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            _roomsData.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
