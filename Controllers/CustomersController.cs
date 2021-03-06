using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Final_Project.Models;

namespace Rent_A_Car_Final_Project.Controllers
{
    [Authorize(Roles = "Administrator")]
    //Customer controller only used by admin
    public class CustomersController : Controller
    {
        private readonly Rent_A_Car_Final_ProjectDataContext _context;

        public CustomersController(Rent_A_Car_Final_ProjectDataContext context)
        {
            _context = context;
        }

        // GET: Customers
        //Gets all customers
       

        public IActionResult Index()
        {
            return View(_context.Customer.ToList());
        }

        // GET: Customers/Details/5
        //Gets the detils of a customer.
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer =  _context.Customer
                .FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }



       
        // GET: Customers/Edit/5
        //Gets the customer for edit.
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates the customer.
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Email,ContactNumber")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                     _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
       //Gets the customer for delete.
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = _context.Customer
                .FirstOrDefault(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        //Deletes a customer.
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var customer =  _context.Customer.Find(id);
            _context.Customer.Remove(customer);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Customer exists check lamda query.
        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Id == id);
        }
    }
}
