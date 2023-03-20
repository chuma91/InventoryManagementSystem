using InventoryManagementSystem.ViewModels;
using InventoryManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.BusinessLogic
{
    public class SupplierBusinessLogic
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        public List<Supplier> GetAllSuppliers()
        {
            List<Supplier> sup = new List<Supplier>();
            try
            {
                sup = db.GetAllSuppliersFromDatabase().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return sup;
        }

        public bool RemoveSupplierById(int SupplierId)
        {
            bool result = false;
            try
            {
                var Find = db.Suppliers.ToList().FirstOrDefault(x => x.Supplier_ID == SupplierId && x.IsDeleted == false);
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

        public Supplier GetSupplierById(int SupplierId)
        {
            Supplier supplier = new Supplier();
            try
            {
                supplier = db.Suppliers.ToList().FirstOrDefault(x => x.Supplier_ID == SupplierId && x.IsDeleted == false);
            }
            catch
            {
                return null;
            }
            return supplier;

        }
        public bool UpdateSupplierById(SupplierViewModel supplierViewModel)
        {
            bool result = false;
            try
            {
                var Find = db.Suppliers.ToList().FirstOrDefault(x => x.Supplier_ID == supplierViewModel.SupplierID && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.Supplier_Name = supplierViewModel.SupplierName;
                    Find.Supplier_Email = supplierViewModel.SuppplierEmail;
                    Find.Supplier_Telephone_Number = supplierViewModel.TelephoneNumber;
                   

                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool AddNewSupplier(SupplierViewModel supplierViewModel)
        {
            bool result = false;
            try
            {
                Supplier obj = new Supplier();
                obj.Supplier_Name = supplierViewModel.SupplierName;
                obj.Supplier_Email = supplierViewModel.SuppplierEmail;
                obj.Supplier_Telephone_Number = supplierViewModel.TelephoneNumber;
                obj.IsDeleted = false;

                db.Suppliers.Add(obj);
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