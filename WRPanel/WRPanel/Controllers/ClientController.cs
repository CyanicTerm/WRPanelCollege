using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WRPanel.Models;
using WRPanel.Repository.IRepository;
using WRPanel.Utility;

namespace WRPanel.Controllers
{
    [Authorize]
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
        [Authorize(Roles =SD.Role_Admin + "," + SD.Role_Owner + "," + SD.Role_Manager)]
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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Owner + "," + SD.Role_Manager)]
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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Owner)]
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
        [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Owner)]
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