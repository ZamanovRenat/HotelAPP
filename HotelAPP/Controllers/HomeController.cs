using HotelAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using HotelAPP.Context;
using Microsoft.AspNetCore.Authorization;

namespace HotelAPP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        HotelContext _context;

        public HomeController(ILogger<HomeController> logger, HotelContext context)
        {
            _logger = logger;
            _context = context;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View(_context.Rooms.ToList());
        }
        [HttpGet]
        public IActionResult CheckIn(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.ClientId = id;
            return View();
        }

        public string CheckIn(Checkin checkin)
        {
            _context.Checkins.Add(checkin);
            _context.SaveChanges();
            return $"Спасибо, {checkin.ClientId}, за бронирование номера";
        }
    }
}
