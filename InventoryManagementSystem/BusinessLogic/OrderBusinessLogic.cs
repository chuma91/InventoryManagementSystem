using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagementSystem.BusinessLogic
{
    public class OrderBusinessLogic
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        public List<Order> GetAllOrders()
        {
            List<Order> od = new List<Order>();
            try
            {
                od = db.Orders.ToList().FindAll(x => x.IsDeleted == false);
                
            }
            catch (Exception ex)
            {
                return null;
            }

            return od;
        }



    
        public bool RemoveOrderById(int OrderId)
        {
            bool result = false;
            try
            {
                var Find = db.Orders.ToList().FirstOrDefault(x => x.Order_ID == OrderId && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.IsDeleted = true;
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }
            return result;
        }

        public Order GetOrderById(int orderId)
        {
            Order order = new Order();
            try
            {
                order = db.Orders.ToList().FirstOrDefault(x => x.Order_ID == orderId && x.IsDeleted == false);
            }
            catch
            {
                return null;
            }
            return order;

        }
        public bool UpdateOrdeById(OrdersViewModel orderViewModel)
        {
            bool result = false;
            try
            {
                var Find = db.Orders.ToList().FirstOrDefault(x => x.Order_ID == orderViewModel.OrderID && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.Payment_Recieved = orderViewModel.PaymentRecieved;
                    

                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool AddNewOrder(OrdersViewModel orderViewModel)
        {
            bool result = false;
            try
            {
                Order obj = new Order();
                obj.Customer_ID= orderViewModel.CustomerID.ToString();
                obj.C_Supplier_ID = orderViewModel.SupplierID;
                obj.Payment_Recieved = orderViewModel.PaymentRecieved;
                obj.ProductName = orderViewModel.ProductName;
                obj.Date_Sold = orderViewModel.DateSold;
                
                obj.IsDeleted = false;

                db.Orders.Add(obj);
                db.SaveChanges();
                result = true;
            }
            catch (Exception ex)
            {

            }

            return result;
        }
    }
}