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

        //Function here
        public bool isLogined()
        {
            if (Session[CommonConstant.USER_ID] == null || Session[CommonConstant.USER_PASSWORD] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public ActionResult Login()
        {
            if (isLogined() == true)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
        // GET: Admin/Admin
        public ActionResult Index(string id,string password)
        {
            //Check if Session is available
            if(isLogined() == false)
            {
                foreach (administrator a in db.administrators)
                {
                    //Check user's id and password
                    if (id == a.administratorid.Replace(" ", string.Empty))
                    {
                        if (password == a.administratorpassword.Replace(" ", string.Empty))
                        {
                            Session.Add(CommonConstant.USER_ID,id);
                            Session.Add(CommonConstant.USER_PASSWORD,password);
                            return View();
                        }
                    }
                }
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }
    }
}