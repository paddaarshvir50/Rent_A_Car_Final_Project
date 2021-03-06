using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Final_Project.Models;

namespace Rent_A_Car_Final_Project.Controllers
{
    //Booking controller
    public class BookingsController : Controller
    {
        private readonly Rent_A_Car_Final_ProjectDataContext _context;

        public BookingsController(Rent_A_Car_Final_ProjectDataContext context)
        {
            _context = context;
        }

        // GET: Bookings
        //Gets all booking to be viewed by the Admin Uses a lamda query
        [Authorize(Roles="Administrator")]
        public async Task<IActionResult> Index()
        {
            var rent_A_Car_Final_ProjectDataContext = _context.Booking.Include(b => b.Car).Include(b => b.Customer);
            return View( rent_A_Car_Final_ProjectDataContext.ToList());
        }

        // GET: Bookings/Details/5
        //Gets the details of a booking viewd by Admin uses a lamda query 
        [Authorize(Roles = "Administrator")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking =  _context.Booking
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .FirstOrDefault(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        //Creates a booking. Only by the customer.
        [Authorize(Roles = "Customer")]
        public IActionResult Create(int id)
        {
            Booking booking = new Booking();

            booking.CustomerId = Int32.Parse(HttpContext.Session.GetString("userId"));
            booking.CarId = id;

            _context.Booking.Add(booking);

            _context.SaveChanges();

            var savedBooking = _context.Booking.
                Include(b => b.Car)
                .Include(b => b.Customer).FirstOrDefault(b=>b.Id == booking.Id);

            savedBooking.Car.Booked = true;
            _context.SaveChanges();
            return View(savedBooking);
        }


        // GET: Bookings/Edit/5
        //Gets the boking for edit
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = _context.Booking.Find(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "RegistrationId", booking.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Name", booking.CustomerId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the booking 
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,CustomerId,CarId")] Booking booking)
        {
            if (id != booking.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id))
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
            ViewData["CarId"] = new SelectList(_context.Set<Car>(), "Id", "Id", booking.CarId);
            ViewData["CustomerId"] = new SelectList(_context.Set<Customer>(), "Id", "Id", booking.CustomerId);
            return View(booking);
        }

        // GET: Bookings/Delete/5
        //Gets The booking for delete. Only admin is allowed
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking =_context.Booking
                .Include(b => b.Car)
                .Include(b => b.Customer)
                .FirstOrDefault(m => m.Id == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        //Deletes the booking admin only
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var booking =_context.Booking
               .Include(b => b.Car)
               .Include(b => b.Customer)
               .FirstOrDefault(m => m.Id == id);
            booking.Car.Booked = false;
            _context.Booking.Remove(booking);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Lam da query to check the booking exists .
        private bool BookingExists(int id)
        {
            return _context.Booking.Any(e => e.Id == id);
        }
    }
}
