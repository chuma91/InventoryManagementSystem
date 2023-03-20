using InventoryManagementSystem.BusinessLogic;
using InventoryManagementSystem.ViewModels;
using InventoryManagementSystem.Models;
using System;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class SuppliersController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        SupplierBusinessLogic supplierBusiness = new SupplierBusinessLogic();
        // GET: Products
        public ActionResult GetAllSuppliers()
        {
            return View(supplierBusiness.GetAllSuppliers());
        }

        //Remove Suppliers
        [HttpPost]
        public ActionResult RemoveSupplier(int Id)
        {
            Boolean result = supplierBusiness.RemoveSupplierById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditSupplier(int Id)
        {
            Supplier result = supplierBusiness.GetSupplierById(Id);
            TempData["ID"] = Id;

            return View(result);
        }
        [HttpPost]
        public ActionResult EditSupplier(SupplierViewModel supplierViewModel)
        {
            Boolean result = supplierBusiness.UpdateSupplierById(supplierViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddSupplier()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSupplier(SupplierViewModel supplierViewModel)
        {
            Boolean result = supplierBusiness.AddNewSupplier(supplierViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}