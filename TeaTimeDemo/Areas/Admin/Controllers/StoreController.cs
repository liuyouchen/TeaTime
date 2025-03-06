using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeaTimeDemo.DataAccess.Data;
using TeaTimeDemo.DataAccess.Repository.IRepository;
using TeaTimeDemo.Models;
using TeaTimeDemo.Models.ViewModels;
using TeaTimeDemo.Utility;

namespace TeaTimeDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class StoreController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;//application connectobject
        public StoreController(IUnitOfWork unitOfWork) //constructor: applicationdbcontext(need register) use DI to this controller
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Store> objStoreList = _unitOfWork.Store.GetAll().ToList(); //use _db connect DB catch data
            return View(objStoreList);
        }
        //public IActionResult Create()
        //{
        //    StoreVM productVM = new()
        //    {
        //        CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem { Text = u.Name, Value = u.Id.ToString() }), Store = new Store()
        //    };
        //    return View(productVM);
        //    //redirect view:create.cshtml
        //}
        ////Convention over Configuration: dont use configuration
        //[HttpPost]
        //public IActionResult Create(StoreVM productVM)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Store.Add(productVM.Store);
        //        _unitOfWork.Save();
        //        TempData["success"] = "類別產品成功！";//key-value pair
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        productVM.CategoryList = _unitOfWork.Category.GetAll().Select(u => new SelectListItem
        //        {
        //            Text = u.Name,
        //            Value = u.Id.ToString()
        //        });
        //        return View(productVM);
        //    }
        //    return View();
        //}
        ////recieve data from create.cshtml then save to db
        //public IActionResult Edit(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Store? StoreFromDb = _unitOfWork.Store.Get(u => u.Id == id);
        //    if (StoreFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(StoreFromDb);
        //}
        //[HttpPost]
        //public IActionResult Edit(Store? obj)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _unitOfWork.Store.Update(obj);
        //        _unitOfWork.Save();
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}
        ////nullable type: int?
        public IActionResult Upsert(int? id)
        {
            if (id == null || id == 0)
            {
                return View(new Store());
            }
            else
            {
                Store storeObj = _unitOfWork.Store.Get(u => u.Id == id);
                return View(storeObj);//view model data
            }
        }
        [HttpPost]
        public IActionResult Upsert(Store storeObj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                if (storeObj.Id == 0)
                {
                    _unitOfWork.Store.Add(storeObj);
                }
                else
                {
                    _unitOfWork.Store.Update(storeObj);
                }
                _unitOfWork.Save();
                TempData["success"] = "店鋪新增成功！";
                return RedirectToAction("Index");
            }
            else
            {
                return View(storeObj);
            }
        }
        //public IActionResult Delete(int? id)
        //{
        //    if (id == null || id == 0)
        //    {
        //        return NotFound();
        //    }
        //    Store StoreFromDb = _unitOfWork.Store.Get(u => u.Id == id);
        //    if (StoreFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(StoreFromDb);
        //}
        //[HttpPost,ActionName("Delete")]
        //public IActionResult DeletePost(int? id)
        //{
        //    Store? obj = _unitOfWork.Store.Get(u => u.Id == id);
        //    if (obj == null)
        //    {
        //        return NotFound();
        //    }
        //    _unitOfWork.Store.Remove(obj);
        //    _unitOfWork.Save();
        //    TempData["success"] = "類別刪除成功！";
        //    return RedirectToAction("Index");
        //}
        //cant exist the same func name. action delete

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Store> objStoreList = _unitOfWork.Store.GetAll().ToList();
            return Json(new { data = objStoreList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var storeToBeDeleted = _unitOfWork.Store.Get(u => u.Id == id);
            if (storeToBeDeleted == null)
            {
                return Json(new { success = false, message = "刪除失敗" });
            }

            _unitOfWork.Store.Remove(storeToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "刪除成功" });
        }
        #endregion
    }
}
