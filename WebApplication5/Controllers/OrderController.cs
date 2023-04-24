using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using WebApplication5.Data;
using WebApplication5.Models;
using WebApplication5.Server.Controllers;

namespace WebApplication5.Controllers
{
    [Authorize(Policy = "IsCustomer")]
    public class OrderController : Controller
    {
        WebApplication5Context _context;

        public OrderController(WebApplication5Context context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("EventId, Quantity")] OrderDetail orderDetail, string ReturnUrl = "/")
        {
            var current_cart = _context.TicketOrders.OrderByDescending(o => o.OrderId).FirstOrDefault();
            if (current_cart == null || current_cart.BuyDate != null)
            {
                int accountId = AccountController.Account.AccountId;
                current_cart = new TicketOrder()
                {
                    CustomerId = _context.Customers.SingleOrDefault(c => c.AccountId == accountId).CustomerId,
                };
                _context.Add(current_cart);
                _context.SaveChanges();
            }
            if (ModelState.IsValid)
            {
                orderDetail.OrderId = current_cart.OrderId;
                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return LocalRedirect(ReturnUrl); 
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Index()
        {
            var current_cart = _context.TicketOrders.OrderByDescending(o => o.OrderId).FirstOrDefault();
            if (current_cart == null || current_cart.BuyDate != null)
            {
                int accountId = AccountController.Account.AccountId;
                current_cart = new TicketOrder()
                {
                    CustomerId = _context.Customers.SingleOrDefault(c => c.AccountId == accountId).CustomerId,
                };
                _context.Add(current_cart);
                _context.SaveChanges();
            }
            return View(current_cart.OrderDetails);
        }
    }
}
