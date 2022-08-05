using BL;
using Entities.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PL.Controllers
{
    public class AccountController : Controller
    {
       public Repository<TBL_User> repouser = new Repository<TBL_User>();
       public Repository<TBL_User_Role_Match> repomatch = new Repository<TBL_User_Role_Match>();
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(TBL_User modal)
        {
            if (ModelState.IsValid)
            {

                TBL_User user = repouser.Find(u => u.UserName == modal.UserName && u.Password == modal.Password);
                    if (user != null)
                    {
                        var role = repomatch.Find(x => x.TBL_UserId == user.Id);
                        FormsAuthentication.SetAuthCookie(user.UserName, false);
                        Session["KAD"] = user.UserName;
                        Session["KID"] = user.Id;
                        HttpCookie cerezim = new HttpCookie("cerezdosyam");
                        cerezim["KID"] = Convert.ToString(user.Id);
                        cerezim["KAD"] = Convert.ToString(user.UserName);
                        cerezim.Expires = DateTime.Now.AddDays(20);
                        Response.Cookies.Add(cerezim);
                        if (role.TBL_RoleId == 1)
                        {
                            return RedirectToAction("Index", "Admin");
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }



                    }
                    else
                    {
                    TBL_User user2 = repouser.Find(u => u.Email == modal.UserName && u.Password == modal.Password);
                        if (user2 != null)
                        {
                            var role = repomatch.Find(x => x.TBL_UserId == user.Id);
                            FormsAuthentication.SetAuthCookie(user2.UserName, false);
                            Session["KAD"] = user2.UserName;
                            Session["KID"] = user2.Id;
                            HttpCookie cerezim = new HttpCookie("cerezdosyam");
                            cerezim["KID"] = Convert.ToString(user.Id);
                            cerezim["KAD"] = Convert.ToString(user.UserName);
                            cerezim.Expires = DateTime.Now.AddDays(20);
                            Response.Cookies.Add(cerezim);
                            if (role.TBL_RoleId == 1)
                            {
                                return RedirectToAction("Index", "Admin");
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home");
                            }
                        }
                        else
                        {
                            TempData["Durum"] = "Giriş Başarısız";
                            ModelState.AddModelError("", "Invalid User Name or Password");
                            return View(modal);
                        }
                    }
                
            }
            else
            {
                return View(modal);
            }
        }
        public ActionResult LogOff()
        {
            Session.RemoveAll();
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public ActionResult Register()
        {
            string password = Membership.GeneratePassword(12, 1);
            return View();
        }

        [HttpPost]
        public ActionResult Register(string Ad,string Soyad, string KAD, string Email, string Password)
        {
            var kullanici_var_mi = repouser.Find(x => x.UserName == KAD || x.Email == Email);
            if (kullanici_var_mi == null)
            {
                TBL_User users = new TBL_User();
                users.Name = Ad;
                users.SurName = Soyad;
                users.UserName = KAD;
                users.Email = Email;
                users.Password = Password;
                users.ActiveGuid = Guid.NewGuid();
                users.CreatedOnByDate = DateTime.Now;
                users.ModifiedOnByDate = DateTime.Now.AddMinutes(5);
                users.IsActive = true;
                repouser.Insert(users);
                  var deger = repouser.Find(x => x.UserName == users.UserName && x.Name == users.Name&&x.SurName==users.SurName);
                TBL_User_Role_Match cc = new TBL_User_Role_Match();
                cc.TBL_RoleId = 2;
                cc.TBL_UserId = deger.Id;
                repomatch.Insert(cc);
                  TempData["Durum"] = "Kayıt Oluşturuldu";
                return RedirectToAction("Login");
            }
            else
            {

                TempData["Durum"] = "Aynı Kullanıcı Adı Veya Email'de kullanıcı bulundu...";
                return RedirectToAction("Login");
            }
        }
    }
}