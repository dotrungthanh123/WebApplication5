﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EventsController : Controller
    {
        public IActionResult Allevents()
        {
            return View();
        }
    }
}
