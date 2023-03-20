using InventoryManagementSystem.BusinessLogic;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        CategoryBusinessLogic categoryBusiness = new CategoryBusinessLogic();
        // GET: Categories
        public ActionResult GetAllCategories()
        {
            return View(categoryBusiness.GetAllCategories());
        }
 
        
        //Remove Categories
        [HttpPost]
        public ActionResult RemoveCategory(int Id)
        {
            Boolean result = categoryBusiness.RemoveCategoryById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditCategory(int Id)
        {
            Category result = categoryBusiness.GetCategoryById(Id);
            TempData["ID"] = Id;

            return View(result);
        }
        [HttpPost]
        public ActionResult EditCategory(CategoriesViewModel categoriesViewModel)
        {
            Boolean result = categoryBusiness.UpdateCategoriesById(categoriesViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCategory(CategoriesViewModel categoriesViewModel)
        {
            Boolean result = categoryBusiness.AddNewCategories(categoriesViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
     



    }
}