using HotelAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using HotelAPP.Context;

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
            return $"Спасибо, {checkin.Client}, за бронирование номера";
        }
    }
}
