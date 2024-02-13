using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WRPanel.Data;
using WRPanel.Models;
using WRPanel.Repository.IRepository;

namespace WRPanel.Controllers
{
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;
        public EventController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            var events = _context.Set<Event>();
            return new JsonResult(events);
        }
        //Create - GET
        public IActionResult Create()
        {
            return View();
        }

        //Delete - GET
        public IActionResult Delete(int? id)
        {
            var clientFromDb = _unitOfWork.Event.GetFirstOrDefault(c => c.Id == id);
            if (clientFromDb == null)
            {
                return NotFound();
            }

            return View(clientFromDb);
        }

        //Delete - POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _unitOfWork.Event.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Event.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Klient usunięty pomyślnie";

            return RedirectToAction("Index");
        }

        //Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Event obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Event.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Wydarzenie dodane pomyślnie";

                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
