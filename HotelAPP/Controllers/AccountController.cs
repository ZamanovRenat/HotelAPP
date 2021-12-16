using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HotelAPP.Context;
using HotelAPP.Domain.Entities;
using HotelAPP.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace HotelAPP.Controllers
{
    public class AccountController : Controller
    {
        private readonly HotelContext _context;

        public AccountController(HotelContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
    }
}
