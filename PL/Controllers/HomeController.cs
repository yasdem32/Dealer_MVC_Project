using BL;
using Entities.Class;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    [Authorize(Roles = "Admin")]
    [AuditAttribute]
    public class HomeController : Controller
    {
        public Repository<TBL_User> repouser = new Repository<TBL_User>();
        public Repository<TBL_User_Role_Match> repomatch = new Repository<TBL_User_Role_Match>();

   
        public ActionResult Index()
        {
             return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}