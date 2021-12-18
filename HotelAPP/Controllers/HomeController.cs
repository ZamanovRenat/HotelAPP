using HotelAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using HotelAPP.Context;
using HotelAPP.Domain.Entities;
//using HotelAPP.Services.InSQL;
using HotelAPP.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace HotelAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRoomsData _roomsData;

        public HomeController(ILogger<HomeController> logger, IRoomsData roomsData)
        {
            _logger = logger;
            _roomsData = roomsData;
        }
        public IActionResult Index()
        {
            return View(_roomsData.getAllRooms());
        }

        public IActionResult Details(int id)
        {
            var room = _roomsData.getRoom(id);

            if (room == null) return NotFound();

            return View(room);
        }
        public IActionResult Create() => View("Edit", new RoomViewModel());

        public IActionResult Edit(int? id)
        {
            if (id is null)
                return View(new RoomViewModel());

            var room = _roomsData.getRoom((int) id);
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
