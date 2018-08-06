using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        HOTELEntities db = new HOTELEntities();
        public ActionResult Login()
        {
            return View();
        }
        // GET: Admin/Admin
        public ActionResult Index(string id,string password)
        {
            foreach (administrator a in db.administrators)
            {
                if (id == a.administratorid.Replace(" ",string.Empty))
                {
                    if (password == a.administratorpassword.Replace(" ",string.Empty))
                    {
                        return View();
                    }
                }
            }
            return RedirectToAction("Login","Admin");
        }
    }
}