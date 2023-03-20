using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.BusinessLogic
{
    public class CustomerBusinessLogic
    {

        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        public List<Customer> GetAllCustomers()
        {
            List<Customer> sup = new List<Customer>();
            try
            {
                sup = db.GetAllCustomersFromDatabase().ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

            return sup;
        }

        public bool RemoveCustomerById(int CustomerId)
        {
            bool result = false;
            try
            {
                var Find = db.Customers.ToList().FirstOrDefault(x => x.Customer_ID== CustomerId && x.IsDeleted == false);
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

        
        public Customer GetCustomerById(int CustomerId)
        {
            Customer customer = new Customer();
            try
            {
                customer = db.Customers.ToList().FirstOrDefault(x => x.Customer_ID == CustomerId && x.IsDeleted == false);
            }
            catch
            {
                return null;
            }
            return customer;

        }
        public bool UpdateCustomerById(CustomersViewModel customerViewModel)
        {
            bool result = false;
            try
            {
                var Find = db.Customers.ToList().FirstOrDefault(x => x.Customer_ID == customerViewModel.CustomerID && x.IsDeleted == false);
                if (Find != null)
                {
                    Find.Customer_Name = customerViewModel.CustomerName;
                    Find.Customer_Email = customerViewModel.CustomerEmail;
                    Find.Customer_Telephone_Name = customerViewModel.CustomerTelephoneNumber;
                    Find.Customer_Address = customerViewModel.CustomerAddress;

                    db.SaveChanges();
                    result = true;
                }
            }
            catch (Exception ex)
            {

            }

            return result;
        }

        public bool AddNewCustomer(CustomersViewModel customerViewModel)
        {
            bool result = false;
            try
            {
                Customer obj= new Customer();
                obj.Customer_Name = customerViewModel.CustomerName;
                obj.Customer_Email = customerViewModel.CustomerEmail;
                obj.Customer_Telephone_Name = customerViewModel.CustomerTelephoneNumber;
                obj.Customer_Address = customerViewModel.CustomerAddress.ToString();
                obj.IsDeleted = false;

                db.Customers.Add(obj);
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