using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WRPanel.Models;
using WRPanel.Repository.IRepository;

namespace WRPanel.Controllers
{
    public class ClientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Client> clients = _unitOfWork.Client.GetAll();
            return View(clients);
        }

        //Create - GET
        public IActionResult Create()
        {
            return View();
        }

        //Create - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Client.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Klient dodany pomyślnie";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit - GET
        public IActionResult Edit(int? id)
        {
            var clientFromDb = _unitOfWork.Client.GetFirstOrDefault(c => c.Id == id);
            if (clientFromDb == null)
            {
                return NotFound();
            }

            return View(clientFromDb);
        }

        //Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Client.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Klient edytowany pomyślnie";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete - GET
        public IActionResult Delete(int? id)
        {
            var clientFromDb = _unitOfWork.Client.GetFirstOrDefault(c => c.Id == id);
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
            var obj = _unitOfWork.Client.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Client.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Klient usunięty pomyślnie";

            return RedirectToAction("Index");
        }
    }
}