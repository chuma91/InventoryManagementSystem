using InventoryManagementSystem.BusinessLogic;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace InventoryManagementSystem.Controllers
{
    public class OrdersController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        OrderBusinessLogic orderBusiness = new OrderBusinessLogic();
        // GET: Products
        public ActionResult GetAllOrders()
        {
            return View(orderBusiness.GetAllOrders());
        }

    


        [HttpPost]
        public ActionResult RemoveOrder(int Id)
        {
            Boolean result = orderBusiness.RemoveOrderById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditOrder(int Id)
        {
            Order result = orderBusiness.GetOrderById(Id);
            TempData["ID"] = Id;
            ViewBag.PaymentRecieved = new SelectList(db.Payment_Status.ToList().Where(x => x.IsDeleted == false), "Status_ID", "Status_Name");
            return View(result);
        }
        [HttpPost]
        public ActionResult EditSupplier(OrdersViewModel orderViewModel)
        {
            Boolean result = orderBusiness.UpdateOrdeById(orderViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddOrder()
        {
            ViewBag.Customer_ID = new SelectList(db.Customers.ToList().Where(x => x.IsDeleted == false), "Customer_ID", "Customer_Name");
            ViewBag.Supplier_ID = new SelectList(db.Suppliers.ToList().Where(x => x.IsDeleted == false), "Supplier_ID", "Supplier_Name");
            ViewBag.Category_ID = new SelectList(db.Categories.ToList().Where(x => x.IsDeleted == false), "Category_ID", "CategoryName");
            ViewBag.PaymentRecieved = new SelectList(db.Payment_Status.ToList().Where(x => x.IsDeleted == false), "Status_ID", "Status_Name");
            ViewBag.ProductName = new SelectList(db.Products.ToList().Where(x => x.IsDeleted == false), "Product_Bar_Code", "ProductName");
            return View();
        }
        [HttpPost]
        public ActionResult AddOrder(OrdersViewModel ordersViewModel)
        {
            Boolean result = orderBusiness.AddNewOrder(ordersViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }

      
    }
}