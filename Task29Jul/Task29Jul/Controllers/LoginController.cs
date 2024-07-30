using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Task29Jul.Models;
using System.Web.Helpers;
using System.IO;


namespace Task29Jul.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }


        // POST: Login
        [HttpPost]
        public ActionResult Login(user29 user)
        {
            using (user29JulEntities db = new user29JulEntities())
            {
                var logged_user = db.user29.FirstOrDefault(u => u.Email == user.Email);

                if (logged_user != null && user.PasswordNew == logged_user.PasswordNew)
                {
                    HttpCookie auth = new HttpCookie("AuthCookie", user.Email);
                    auth.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(auth);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password";
                    return View();
                }
            }
        }



        // GET: Login/Create
        public ActionResult Register()
        {
            return View();
        }


        // POST: Login/Create
        [HttpPost]
        public ActionResult Register(user29 data)
        {
            user29JulEntities register = new user29JulEntities();
            var user_data = register.user29.Add(data);
            register.SaveChanges();
            return RedirectToAction("Login", "Login");
        }


        // GET: Login/Logout
        public ActionResult Logout()
        {
            HttpCookie authCookie = Request.Cookies["AuthCookie"];
            if (authCookie != null)
            {
                authCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(authCookie);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Profile()
        {
            HttpCookie authCookie = Request.Cookies["AuthCookie"];
            if (authCookie == null)
            {
                return RedirectToAction("Login");
            }

            string email = authCookie.Value;

            using (user29JulEntities db = new user29JulEntities())
            {
                var user = db.user29.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return RedirectToAction("Login");
                }

                return View(user);
            }
        }

        // GET: Login/ResetPassword
        public ActionResult ResetPassword()
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            var model = new ResetPasswordViewModel();
            return View(model);
        }

        // POST: Login/ResetPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (user29JulEntities db = new user29JulEntities())
                {
                    HttpCookie authCookie = Request.Cookies["AuthCookie"];
                    if (authCookie == null)
                    {
                        return RedirectToAction("Login");
                    }

                    string email = authCookie.Value;

                    var user = db.user29.FirstOrDefault(u => u.Email == email);
                    if (user != null)
                    {
                        user.PasswordNew = model.NewPassword;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();

                        ViewBag.SuccessMessage = "Password has been reset successfully.";
                        return View();
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "User not found.";
                        return View();
                    }
                }
            }

            return View(model);
        }


        public ActionResult EditProfile()
        {
            if (Request.Cookies["AuthCookie"] == null)
            {
                return RedirectToAction("Login", "Login");
            }

            string email = Request.Cookies["AuthCookie"].Value;
            using (user29JulEntities db = new user29JulEntities())
            {
                var user = db.user29.FirstOrDefault(u => u.Email == email);
                if (user == null)
                {
                    return HttpNotFound();
                }

                var model = new UserProfileViewModel
                {
                    Email = user.Email,
                    UserName = user.UserName,
                 };

                return View(model);
            }
        }

        // EditProfile POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (user29JulEntities db = new user29JulEntities())
                {
                    var user = db.user29.FirstOrDefault(u => u.Email == model.Email);
                    if (user != null)
                    {
                        user.UserName = model.UserName;

                        if (!string.IsNullOrWhiteSpace(model.NewPassword))
                        {
                            user.PasswordNew = model.NewPassword;
                        }

                        if (model.ProfileImage != null && model.ProfileImage.ContentLength > 0)
                        {
                            var fileName = Path.GetFileName(model.ProfileImage.FileName);
                            var path = Path.Combine(Server.MapPath("~/Images/ProfileImages"), fileName);
                            model.ProfileImage.SaveAs(path);

                            user.images = "/Images/ProfileImages/" + fileName;
                        }

                        db.SaveChanges();
                        return RedirectToAction("Profile", "Login");
                    }

                    return HttpNotFound();
                }
            }

            return View(model);
        }
    }
}