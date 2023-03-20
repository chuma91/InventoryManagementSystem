using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.ViewModels
{
    public class OrdersViewModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductBarCode { get; set; }
        public string ProductName { get; set; }
        public int SupplierID { get; set; }

        public int CategoryID { get; set; }
        public DateTime DateSold { get; set; }
        public string PaymentRecieved { get; set; }
       
        

    }
}