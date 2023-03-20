using   InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System;
using System.Linq;
using System.Web;

namespace InventoryManagementSystem.BusinessLogic
{
    public class AccountBusinessLogic
    {

        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        public User SearchExistingUser(string EmailAddress, string Password)
        {
            User List = new User();
            try
            {
                List = db.Users.Where(a => a.EmailAddress.ToLower().Equals(EmailAddress.ToLower()) && a.PasswordHash.Equals(Password) && a.IsDeleted == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            return List;
        }

        public User CheckUserIfUserExist(string EmailAddress)
        {
            User List = new User();
            try
            {
                List = db.Users.Where(a => a.EmailAddress.ToLower().Equals(EmailAddress.ToLower()) && a.IsDeleted == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            return List;
        }

        public bool RegisterNewUser(RegisterViewModel registerViewModel)
        {
            bool Saved = false;
            try
            {
                User obj = new User();
                // checking if user exist
                var existing = CheckUserIfUserExist(registerViewModel.EmailAddress);
                if (existing == null)
                {
                    obj.FirstName = registerViewModel.FirstName;
                    obj.LastName = registerViewModel.LastName;
                    obj.PasswordHash = registerViewModel.Password;
                    obj.RoleId = registerViewModel.RoleId;
                    obj.PhoneNumber = registerViewModel.PhoneNumber;
                    obj.EmailAddress = registerViewModel.EmailAddress;

                    obj.DateCreated = DateTime.Now;
                    obj.IsDeleted = false;
                    obj.RememberMe = false;
                    db.Users.Add(obj);
                    db.SaveChanges();
                    Saved = true;
                }
                else
                {
                    Saved = false;
                }
            }
            catch
            {
                Saved = false;
            }

            return Saved;

        }
    }
}