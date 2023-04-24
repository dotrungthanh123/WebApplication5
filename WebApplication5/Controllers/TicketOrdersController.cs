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
    public class TicketOrdersController : Controller
    {
        private readonly WebApplication5Context _context;

        public TicketOrdersController(WebApplication5Context context)
        {
            _context = context;
        }

        // GET: TicketOrders
        public async Task<IActionResult> Index()
        {
            var webApplication5Context = _context.TicketOrders.Include(t => t.Customer);
            return View(await webApplication5Context.ToListAsync());
        }

        // GET: TicketOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TicketOrders == null)
            {
                return NotFound();
            }

            var ticketOrder = await _context.TicketOrders
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ticketOrder == null)
            {
                return NotFound();
            }

            return View(ticketOrder);
        }

        // GET: TicketOrders/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        // POST: TicketOrders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,CustomerId,BuyDate")] TicketOrder ticketOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ticketOrder.CustomerId);
            return View(ticketOrder);
        }

        // GET: TicketOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TicketOrders == null)
            {
                return NotFound();
            }

            var ticketOrder = await _context.TicketOrders.FindAsync(id);
            if (ticketOrder == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ticketOrder.CustomerId);
            return View(ticketOrder);
        }

        // POST: TicketOrders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,CustomerId,BuyDate")] TicketOrder ticketOrder)
        {
            if (id != ticketOrder.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketOrder);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketOrderExists(ticketOrder.OrderId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CustomerId", ticketOrder.CustomerId);
            return View(ticketOrder);
        }

        // GET: TicketOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TicketOrders == null)
            {
                return NotFound();
            }

            var ticketOrder = await _context.TicketOrders
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (ticketOrder == null)
            {
                return NotFound();
            }

            return View(ticketOrder);
        }

        // POST: TicketOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TicketOrders == null)
            {
                return Problem("Entity set 'WebApplication5Context.TicketOrders'  is null.");
            }
            var ticketOrder = await _context.TicketOrders.FindAsync(id);
            if (ticketOrder != null)
            {
                _context.TicketOrders.Remove(ticketOrder);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketOrderExists(int id)
        {
          return (_context.TicketOrders?.Any(e => e.OrderId == id)).GetValueOrDefault();
        }
    }
}
