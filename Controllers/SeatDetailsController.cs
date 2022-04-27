#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusTicketBookingSystem.Models;

namespace BusTicketBookingSystem.Controllers
{
    public class SeatDetailsController : Controller
    {
        private readonly BusTicketBookingContext _context;

        public SeatDetailsController(BusTicketBookingContext context)
        {
            _context = context;
        }

        // GET: SeatDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.SeatDetails.ToListAsync());
        }

        // GET: SeatDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatDetail = await _context.SeatDetails
                .FirstOrDefaultAsync(m => m.SeatId == id);
            if (seatDetail == null)
            {
                return NotFound();
            }

            return View(seatDetail);
        }

        // GET: SeatDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SeatDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeatId,SeatNumber,SeatType")] SeatDetail seatDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seatDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(seatDetail);
        }

        // GET: SeatDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatDetail = await _context.SeatDetails.FindAsync(id);
            if (seatDetail == null)
            {
                return NotFound();
            }
            return View(seatDetail);
        }

        // POST: SeatDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeatId,SeatNumber,SeatType")] SeatDetail seatDetail)
        {
            if (id != seatDetail.SeatId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seatDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeatDetailExists(seatDetail.SeatId))
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
            return View(seatDetail);
        }

        // GET: SeatDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seatDetail = await _context.SeatDetails
                .FirstOrDefaultAsync(m => m.SeatId == id);
            if (seatDetail == null)
            {
                return NotFound();
            }

            return View(seatDetail);
        }

        // POST: SeatDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seatDetail = await _context.SeatDetails.FindAsync(id);
            _context.SeatDetails.Remove(seatDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeatDetailExists(int id)
        {
            return _context.SeatDetails.Any(e => e.SeatId == id);
        }
    }
}
