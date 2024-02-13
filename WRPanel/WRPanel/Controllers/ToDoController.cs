using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WRPanel.Models;
using WRPanel.Repository.IRepository;
using WRPanel.Utility;

namespace WRPanel.Controllers
{
    [Authorize(Roles = SD.Role_Admin)]
    public class ToDoController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public ToDoController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("/")]
        public IActionResult Index()
        {
            IEnumerable<ToDo> clients = _unitOfWork.ToDo.GetAll();
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
        public IActionResult Create(ToDo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDo.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Klient dodany pomyślnie";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Edit - GET
        public IActionResult Edit(int? id)
        {
            var clientFromDb = _unitOfWork.ToDo.GetFirstOrDefault(c => c.Id == id);
            if (clientFromDb == null)
            {
                return NotFound();
            }

            return View(clientFromDb);
        }

        //Edit - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ToDo obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ToDo.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Klient edytowany pomyślnie";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //Delete - GET
        public IActionResult Delete(int? id)
        {
            var clientFromDb = _unitOfWork.ToDo.GetFirstOrDefault(c => c.Id == id);
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
            var obj = _unitOfWork.ToDo.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.ToDo.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Klient usunięty pomyślnie";

            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var toDoList = _unitOfWork.ToDo.GetAll();
            return Json(toDoList);
        }

        [HttpPost]
        public IActionResult InsertClient(ToDo obj)
        {
            _unitOfWork.ToDo.Add(obj);
            _unitOfWork.Save();
            return Json(obj);
        }

        [HttpPut]
        public IActionResult UpdateClient(ToDo obj)
        {
            _unitOfWork.ToDo.Update(obj);
            _unitOfWork.Save();
            return Json(obj);
        }

        [HttpDelete]
        public IActionResult DeleteClient(ToDo obj)
        {
            _unitOfWork.ToDo.Remove(obj);
            _unitOfWork.Save();
            return Json(obj);
        }
        #endregion
    }
}