using HotelAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using HotelAPP.Context;
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
    }
}
