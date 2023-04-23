using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class EventsController : Controller
    {
        private readonly WebApplication5Context _context;

        public EventsController(WebApplication5Context context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index()
        {
            var webApplication5Context = _context.Events.Include(a => a.Category).Include(a => a.Retailer);
            return View(await webApplication5Context.ToListAsync());
        }

        public IActionResult AccessDenied() => RedirectToAction(nameof(Index));

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var aevent = await _context.Events
                .Include(a => a.Admin)
                .Include(a => a.Category)
                .Include(a => a.Retailer)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (aevent == null)
            {
                return NotFound();
            }

            return View(aevent);
        }

        // GET: Events/Create
        [Authorize(Policy = "isRetailer")]
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,CategoryId,RetailerId,AdminId,Name,Seat,Price,ApproveDate,StartDate,Address")] Event aevent)
        {
            aevent.RetailerId = 1;
            aevent.AdminId = 3;
            if (ModelState.IsValid)
            {
                _context.Add(aevent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", aevent.CategoryId);
            return View(aevent);
        }

        // GET: Events/Edit/5
        [Authorize(Policy = "isRetailer")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var aevent = await _context.Events.FindAsync(id);
            if (aevent == null)
            {
                return NotFound();
            }
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", aevent.AdminId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", aevent.CategoryId);
            ViewData["RetailerId"] = new SelectList(_context.Retailers, "RetailerId", "RetailerId", aevent.RetailerId);
            return View(aevent);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,CategoryId,RetailerId,AdminId,Name,Seat,Price,ApproveDate,StartDate,Address")] Event aevent)
        {
            if (id != aevent.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aevent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(aevent.EventId))
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
            ViewData["AdminId"] = new SelectList(_context.Admins, "AdminId", "AdminId", aevent.AdminId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryId", aevent.CategoryId);
            ViewData["RetailerId"] = new SelectList(_context.Retailers, "RetailerId", "RetailerId", aevent.RetailerId);
            return View(aevent);
        }

        // GET: Events/Delete/5
        [Authorize(Policy = "isRetailer")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Events == null)
            {
                return NotFound();
            }

            var aevent = await _context.Events
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (aevent == null)
            {
                return NotFound();
            }

            return View(aevent);
        }

        // POST: Events/Delete/5
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Events == null)
            {
                return Problem("Entity set 'WebApplication5Context.Events'  is null.");
            }
            var aevent = await _context.Events.FindAsync(id);
            if (aevent != null)
            {
                _context.Events.Remove(aevent);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
          return (_context.Events?.Any(e => e.EventId == id)).GetValueOrDefault();
        }
    }
}
