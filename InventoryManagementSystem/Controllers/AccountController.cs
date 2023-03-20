using InventoryManagementSystem.BusinessLogic;
using InventoryManagementSystem.Models;
using InventoryManagementSystem.ViewModels;
using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InventoryManagementSystem;

namespace InventoryManagementSystem.Controllers
{    
    public class AccountController : Controller
    {
        InventoryManagementDatabaseEntities db = new InventoryManagementDatabaseEntities();
        EncryptDecryptBusinessLogic Encryption = new EncryptDecryptBusinessLogic();
        AccountBusinessLogic accountBusiness = new AccountBusinessLogic();
    
       // GET: Account
        [HttpGet]
        public ActionResult Login()
        {
            //searchig for existing cookies
            bool cookieExists = Request.Cookies.AllKeys.Contains("authcookies");
            Session["Result"] = "";
            if (cookieExists)
            {
                string CookiesUsername = Request.Cookies["authcookies"]["username"];
                string CookiesPassword = Request.Cookies["authcookies"]["password"];

                string Password = CookiesPassword;
                var objec = db.Users.Where(a => a.EmailAddress.ToLower().Equals(CookiesUsername.ToLower()) && a.PasswordHash.Equals(Password) && a.IsDeleted == false).FirstOrDefault();
                //var objec = db.SearchUser(CookiesUsername.ToLower(), Password);
                if (objec != null)
                {               
                    var RoleObj = db.Roles.ToList().FirstOrDefault(x => x.Id == objec.RoleId && x.IsDeleted == false);
                    Session["RoleName"] = RoleObj.Name.ToString();
                    Session["RoleId"] = objec.RoleId;
                    Session["UserId"] = objec.Id;
                    Session["EmailAddress"] = objec.EmailAddress.ToString();
                    Session["Loginuser"] = objec.FirstName.ToString() + " " + objec.LastName.ToString();

                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    return View();
                }
            }
            else
            {

            }
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Login(LoginViewModel loginViewModel)
        {
            loginViewModel.Password = Encryption.Encrypt(loginViewModel.Password);
            string result = "";
            if(ModelState.IsValid)
            {
               // checking if user is registered
                var objec = accountBusiness.SearchExistingUser(loginViewModel.EmailAddress, loginViewModel.Password);
                if(objec == null)
                {
                    // checking if the user exist
                    var exist = accountBusiness.CheckUserIfUserExist(loginViewModel.EmailAddress);
                    if (exist != null)
                    {
                        result = "IncorrectPassword";
                    }
                    else
                    {
                        result = "UserDoesNotExist";
                    }
                   
                }
                else
                {
                    var RoleObj = db.Roles.ToList().FirstOrDefault(x => x.Id == objec.RoleId && x.IsDeleted == false);
                    Session["RoleName"] = RoleObj.Name.ToString();
                    Session["RoleId"] = objec.RoleId;
                    Session["UserId"] = objec.Id;
                    Session["EmailAddress"] = objec.EmailAddress.ToString();
                    Session["Loginuser"] = objec.FirstName.ToString() + " " + objec.LastName.ToString();
                    result = "User Found";
                }   
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public ActionResult Register()
        {
            
            ViewBag.RoleId = new SelectList(db.Roles.ToList().Where(x => x.IsDeleted == false), "Id", "Name");
          //  ViewBag.TerritoryId = new SelectList(db.Tbl_Roles.Territories.ToList(), "TerritoryID", "TerritoryDescription");
            RegisterViewModel vm = new RegisterViewModel();
 
            return View(vm);
        }
        [HttpPost]
        public  ActionResult Register(RegisterViewModel registerViewModel)
        {
            string result = "";
            bool saved;
            registerViewModel.Password = Encryption.Encrypt(registerViewModel.Password);
            // checking if the user exist
            var exist = accountBusiness.CheckUserIfUserExist(registerViewModel.EmailAddress);
            if (exist != null)
            {
                result = "User Exist";
            }
            else
            {
                saved = accountBusiness.RegisterNewUser(registerViewModel);
                if (saved)
                {
                    result = "User Registered";
                }
            }

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public string GetProfilePicture(int UserId)
        {
            string img = "";
            string Alphabet = "";
            var User = db.Users.ToList().FirstOrDefault(x => x.Id == UserId && x.IsDeleted == false);
            if (User != null)
            {
                Alphabet = User.FirstName.Substring(0, 1);

                img = Alphabet.ToUpper() + ".png";
            }

            return img;
        }

        public ActionResult Logout()
        {
            bool cookieExists = Request.Cookies.AllKeys.Contains("authcookies");
            if (cookieExists)
            {
                Response.Cookies["authcookies"]["username"] = "unknown";
                Response.Cookies["authcookies"]["password"] = "unknown";
            }
            return RedirectToAction("Login", "Account");
        }

        public ActionResult GetRoleName()
        {
            var RoleName = Session["RoleName"].ToString();
            var UserId = (int)Session["UserId"];
            var Sender = Session["UserName"].ToString();

            var result = new { RoleName, UserId, Sender };

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }

      
}