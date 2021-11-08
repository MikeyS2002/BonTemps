using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BonTemps.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BonTemps.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Reservations
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Reservations.ToListAsync());
        }

        // GET: Reservations/Details/5
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // GET: Reservations/Create
        [Authorize(Roles = "Medewerker")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> Create([Bind("ReservationId,Name,Email,Persons,Date,Time,Location,KvkNumber,VatNumber,Address,PostalCode,Price,Service,Comment")] Reservations reservations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservations);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reservations);
        }

        // GET: Reservations/Edit/5
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations.FindAsync(id);
            if (reservations == null)
            {
                return NotFound();
            }
            return View(reservations);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> Edit(int id, [Bind("ReservationId,Name,Email,Persons,Date,Time,Location,KvkNumber,VatNumber,Address,PostalCode,Price,Service,Comment")] Reservations reservations)
        {
            if (id != reservations.ReservationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationsExists(reservations.ReservationId))
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
            return View(reservations);
        }

        // GET: Reservations/Delete/5
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservations = await _context.Reservations
                .FirstOrDefaultAsync(m => m.ReservationId == id);
            if (reservations == null)
            {
                return NotFound();
            }

            return View(reservations);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Medewerker")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservations = await _context.Reservations.FindAsync(id);
            _context.Reservations.Remove(reservations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationsExists(int id)
        {
            return _context.Reservations.Any(e => e.ReservationId == id);
        }

        [Authorize(Roles = "Klant")]
        public IActionResult JouwReserveringen()
        {
            var Email = User.FindFirstValue(ClaimTypes.Email);
            var YourReservation = from e in _context.Reservations
                                   where e.Email == Email
                                   select e;
            return View(YourReservation);
        }

        [Authorize(Roles = "Medewerker")]
        public IActionResult Location1()
        {
            var location = from e in _context.Reservations
                                   where e.Location == "Alkmaar"
                           select e;
            return View(location);
        }
        [Authorize(Roles = "Medewerker")]
        public IActionResult Location2()
        {
            var location = from e in _context.Reservations
                            where e.Location == "Den Helder"
                           select e;
            return View(location);
        }
        [Authorize(Roles = "Medewerker")]
        public IActionResult Location3()
        {
            var location = from e in _context.Reservations
                            where e.Location == "Hoorn"
                           select e;
            return View(location);
        }
        [Authorize(Roles = "Medewerker")]
        public IActionResult Location4()
        {
            var location = from e in _context.Reservations
                            where e.Location == "Schagen"
                           select e;
            return View(location);
        }
        [Authorize(Roles = "Medewerker")]
        public IActionResult Location5()
        {
            var location = from e in _context.Reservations
                            where e.Location == "Zaandam"
                           select e;
            return View(location);
        }
        [Authorize(Roles = "Medewerker")]
        public IActionResult Today()
        {
            var today = DateTime.Now;
            var todays = from e in _context.Reservations
                           where e.Date == today
                           select e;
            return View(todays);
        }
    }
}
