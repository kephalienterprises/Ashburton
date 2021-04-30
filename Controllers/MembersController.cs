using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AshburtonCocWebsite.Data;
using AshburtonCocWebsite.Models;
using Microsoft.AspNetCore.Authorization;

namespace AshburtonCocWebsite.Controllers
{
    [Authorize(Roles = "Member, Admin")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.PrayerRequests.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayerRequest = await _context.PrayerRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prayerRequest == null)
            {
                return NotFound();
            }

            return View(prayerRequest);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Requestor,Request")] PrayerRequest prayerRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prayerRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prayerRequest);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayerRequest = await _context.PrayerRequests.FindAsync(id);
            if (prayerRequest == null)
            {
                return NotFound();
            }
            return View(prayerRequest);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Requestor,Request")] PrayerRequest prayerRequest)
        {
            if (id != prayerRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prayerRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrayerRequestExists(prayerRequest.Id))
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
            return View(prayerRequest);
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prayerRequest = await _context.PrayerRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (prayerRequest == null)
            {
                return NotFound();
            }

            return View(prayerRequest);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prayerRequest = await _context.PrayerRequests.FindAsync(id);
            _context.PrayerRequests.Remove(prayerRequest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrayerRequestExists(int id)
        {
            return _context.PrayerRequests.Any(e => e.Id == id);
        }
    }
}
