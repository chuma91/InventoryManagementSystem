using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.ViewModels
{
    public class CustomersViewModel
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerTelephoneNumber { get; set; }
        public string CustomerAddress { get; set; }
    }
}