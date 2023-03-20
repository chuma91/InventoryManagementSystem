﻿using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Dashboard()
        {
            ViewBag.CountCategories = db.Categories.ToList().FindAll(x => x.IsDeleted == false).Count;
            ViewBag.CountOrders = db.Orders.ToList().FindAll(x => x.IsDeleted == false).Count;
            ViewBag.Products = db.Products.ToList().FindAll(x => x.IsDeleted == false).Count;
            ViewBag.Suppliers = db.Categories.ToList().FindAll(x => x.IsDeleted == false).Count;

            // count Orders where payment = received
            ViewBag.CountOrdersReceived = db.Orders.ToList().FindAll(x => x.IsDeleted == false && x.Payment_Recieved == "Received").Count;
            return View();
        }
    }
}