using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using WRPanel.Models;
using WRPanel.Models.ViewModels;
using WRPanel.Repository.IRepository;

namespace WRPanel.Controllers
{
    public class StorageController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        public StorageController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Upsert - GET
        public IActionResult Upsert(int? id)
        {
            StorageVM storageVM = new()
            {
                Storage = new(),
                ClientList = _unitOfWork.Client.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Phone,
                    Value = i.Id.ToString()
                })
            };

            if (id == null || id == 0)
            {
                return View(storageVM);
            }
            else
            {
                storageVM.Storage = _unitOfWork.Storage.GetFirstOrDefault(i => i.Id == id);
                return View(storageVM);
            }
        }

        //Upsert - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(StorageVM obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Storage.Id == 0)
                {
                    _unitOfWork.Storage.Add(obj.Storage);
                }
                else
                {
                    _unitOfWork.Storage.Update(obj.Storage);
                }

                _unitOfWork.Save();
                TempData["success"] = "Przechowalnia dodana pomyślnie";

                return RedirectToAction("Index");
            }
            return View(obj);
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var storageList = _unitOfWork.Storage.GetAll(includeProperties: "Client");
            return Json(new { data = storageList });
        }

        //Delete - POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Storage.GetFirstOrDefault(c => c.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Podczas usuwania wystąpił błąd" });
            }
            _unitOfWork.Storage.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Przechowalnia usunięta pomyślnie" });
        }
        #endregion
    }
}
