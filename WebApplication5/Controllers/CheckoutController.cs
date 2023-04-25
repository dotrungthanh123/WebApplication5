using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly WebApplication5Context _context;

        public CheckoutController(WebApplication5Context context)
        {
            _context = context;
        }

        // GET: Checkout
        public async Task<IActionResult> Index()
        {
            return View();
        }

        
    }
}
