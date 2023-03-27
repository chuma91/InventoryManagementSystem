using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.ViewModels
{
    public class ProductsViewModel
    {
        public int ProductBarCode { get; set; }
        public string ProductName { get; set; }
        public int SuppliersID { get; set; }
        public string SuppliersName { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public DateTime ProductDateCaptured { get; set; }
        public string Location { get; set; }
        public int ProductStatus { get; set; }
        public string ProductWarranty { get; set; }


    }
}