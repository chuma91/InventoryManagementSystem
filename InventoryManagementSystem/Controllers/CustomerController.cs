using InventoryManagementSystem.BusinessLogic;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class CustomerController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        CustomerBusinessLogic customerBusiness = new CustomerBusinessLogic();
        // GET: Products
        public ActionResult GetAllCustomers()
        {
            return View(customerBusiness.GetAllCustomers());
        }

        
        [HttpPost]
        public ActionResult RemoveCustomer(int Id)
        {
            Boolean result = customerBusiness.RemoveCustomerById(Id);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult EditCustomer(int Id)
        {
            Customer result = customerBusiness.GetCustomerById(Id);
            TempData["ID"] = Id;

            return View(result);
        }
        [HttpPost]
        public ActionResult EditCustomer(CustomersViewModel customersViewModel)
        {
            Boolean result = customerBusiness.UpdateCustomerById(customersViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(CustomersViewModel customersViewModel)
        {
            Boolean result = customerBusiness.AddNewCustomer(customersViewModel);


            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}