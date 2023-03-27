using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class ProductsController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        ProductBusinessLogic productBusiness = new ProductBusinessLogic();
        // GET: Products
        public ActionResult GetAllProducts()
        {
            return View(productBusiness.GetAllProducts());
        }


        //Remove Products
        [HttpPost]
        public ActionResult RemoveProduct(int Id)
        {
            Boolean result = productBusiness.RemoveProcuctById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditProduct(int Id)
        {
            Product result = productBusiness.GetProductById(Id);
            TempData["ID"] = Id;
            ViewBag.Supplier_ID = new SelectList(db.Suppliers.ToList().Where(x => x.IsDeleted == false), "Supplier_ID", "Supplier_Name", result.SupplierID);
            ViewBag.Category_ID = new SelectList(db.Categories.ToList().Where(x => x.IsDeleted == false), "Category_ID", "CategoryName", result.Product_CategoryID);
            ViewBag.ProductStatus = new SelectList(db.Product_Status.ToList().Where(x => x.IsDeleted == false), "Status_ID", "Status_Name");

            return View(result);
        }
        [HttpPost]
        public ActionResult EditProduct(ProductsViewModel productsViewModel)
        {
            Boolean result = productBusiness.UpdateProductById(productsViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            ViewBag.Supplier_ID = new SelectList(db.Suppliers.ToList().Where(x => x.IsDeleted == false), "Supplier_ID", "Supplier_Name");
            ViewBag.Category_ID = new SelectList(db.Categories.ToList().Where(x => x.IsDeleted == false), "Category_ID", "CategoryName");
            ViewBag.ProductStatus = new SelectList(db.Product_Status.ToList().Where(x => x.IsDeleted == false), "Status_ID", "Status_Name");
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(ProductsViewModel productsViewModel)
        {
            Boolean result = productBusiness.AddNewProduct(productsViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public int GetNumberOfProductBycategoryId(int categoryId)
        {
            int number = 0;

            try
            {
                number = db.Products.ToList().FindAll(x => x.Product_CategoryID == categoryId && x.IsDeleted == false).Count;
            }
            catch (Exception ex)
            {
            }

            return number;
        }


      

    }

}