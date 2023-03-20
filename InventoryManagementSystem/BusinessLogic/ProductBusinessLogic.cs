using System;
using System.Collections.Generic;
using System.Linq;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
namespace InventoryManagementSystem
{
    public class ProductBusinessLogic
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();

        public List<Product> GetAllProducts()
        {
            List<Product> pro = new List<Product>();
            try
            {
                pro = db.GetAllProductsFromDatabase().ToList();
                
            }
            catch (Exception ex)
            {
                return null;
            }

            return pro;
        }

        public bool RemoveProcuctById(int ProductId)
        {
            bool result = false;
            try
            {
                var Find = db.Products.ToList().FirstOrDefault(x => x.Product_Bar_Code == ProductId && x.IsDeleted == false);
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

        public Product GetProductById(int ProductId)
        {
            Product product = new Product();
            try
            {
                product = db.Products.ToList().FirstOrDefault(x => x.Product_Bar_Code == ProductId && x.IsDeleted == false);
            }
            catch
            {
                return null;
            }
            return product;
        }

        public bool UpdateProductById(ProductsViewModel productsViewModel)
        {
            bool result = false;
            try
            {
                var Find = db.Products.ToList().FirstOrDefault(x => x.Product_Bar_Code == productsViewModel.ProductBarCode && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.Product_Status = productsViewModel.ProductStatus;                 
                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool AddNewProduct(ProductsViewModel productsViewModel)
        {
            bool result = false;
            try
            {
                Product obj = new Product();
                obj.ProductName = productsViewModel.ProductName;
                obj.SupplierID = productsViewModel.SuppliersID;
                obj.Product_Date_Captured = productsViewModel.ProductDateCaptured;
                obj.Product_CategoryID = productsViewModel.CategoryID;
                obj.Product_Location = productsViewModel.Location;
                obj.Product_Status = productsViewModel.ProductStatus;
                obj.Product_Warranty = productsViewModel.ProductWarranty;
                obj.IsDeleted = false;

                db.Products.Add(obj);
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