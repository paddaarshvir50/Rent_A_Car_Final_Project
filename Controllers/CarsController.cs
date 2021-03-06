using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Rent_A_Car_Final_Project.Models;

namespace Rent_A_Car_Final_Project.Controllers
{
    //Manages car details.
    public class CarsController : Controller
    {
        private readonly Rent_A_Car_Final_ProjectDataContext _context;

        public CarsController(Rent_A_Car_Final_ProjectDataContext context)
        {
            _context = context;
        }

        // GET: Cars
        //Gets all cars using a linq query
        [Authorize(Roles = "Administrator,Customer")]
        public IActionResult Index()
        {
            return View((from cars in _context.Car select cars).ToList());
        }

        // GET: Cars/Details/5
        //Gets details  of a car
        [Authorize(Roles = "Administrator,Customer")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _context.Car
                .FirstOrDefault(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // GET: Cars/Create
        //Gets th create car form.
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Creates the car.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public IActionResult Create([Bind("Id,Make,Model,RentPricePerDay,Booked, RegistrationId,PictureFile")] Car car)
        {
            if (ModelState.IsValid)
            {
                UploadCarImage(car);
                _context.Add(car);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        // GET: Cars/Edit/5
        //Gets the car for update only the admin 
        [Authorize(Roles = "Administrator")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car =  _context.Car.Find(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Updates car.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Make,Model,RentPricePerDay,Booked,RegistrationId,PictureFile")] Car car)
        {
            if (id != car.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    UploadCarImage(car);
                    _context.Update(car);
                   _context.SaveChanges();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarExists(car.Id))
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
            return View(car);
        }

        // GET: Cars/Delete/5
        //Gets the car for delete admin only method.
        [Authorize(Roles = "Administrator")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var car = _context.Car
                .FirstOrDefault(m => m.Id == id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        // POST: Cars/Delete/5
        //Deletes the car.
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var car = _context.Car.Find(id);
            _context.Car.Remove(car);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        //Car exists check using a lamda 
        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.Id == id);
        }


        //Upload the car image to the cars folder.
        private void UploadCarImage(Car Car)
        {

            if (Car.PictureFile != null)
            {
                Car.Picture = Car.PictureFile.FileName;

                var filePath = "./wwwroot/cars/" + Car.PictureFile.FileName;


                if (Car.PictureFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        Car.PictureFile.CopyTo(stream);
                    }
                }
            }


        }
    }
}
