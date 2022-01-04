using Project_SET.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace Project_SET.Controllers
{
    public class AdminLoginController : Controller
    {

        // GET: AdminLogin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost,ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel loginModel)
        {
            if(ModelState.IsValid)
            {
                bool isAuthenticated = WebSecurity.Login(loginModel.UserName, loginModel.Password, loginModel.RememberMe);
                
                if(isAuthenticated)
                {
                    string returnUrl = Request.QueryString["ReturnUrl"];

                    if (returnUrl == null)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                    else
                    {
                        return Redirect(Url.Content(returnUrl));
                    }
                }
            }
            else
            {
                ModelState.AddModelError("","Admin Name or Password are incorrect.");
            }
            return View();
        }
        public ActionResult SignOut()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index","AdminLogin");
        }
    }
}