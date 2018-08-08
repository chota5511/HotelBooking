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
        /// <summary>
        /// Check session is logined or not
        /// </summary>
        /// <returns></returns>
        public bool isLogined()
        {
            if (Session[CommonConstant.ADMIN_ID] == null || Session[CommonConstant.ADMIN_PASSWORD] == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Login Admin: Admin/Admin/Login
        public ActionResult Login()
        {
            if (isLogined() == true)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //Logout Admin: Admin/Admin/Logout
        public ActionResult Logout()
        {
            Session[CommonConstant.ADMIN_ID] = null;
            Session[CommonConstant.ADMIN_PASSWORD] = null;
            return RedirectToAction("Index", "Admin");
        }

        // GET: Admin/Admin
        public ActionResult Index(string id,string password)
        {
            //Check if Session is available
            if(isLogined() == false)
            {
                //Login process
                foreach (administrator a in db.administrators)
                {
                    //Check user's id and password
                    if (id == a.administratorid.Replace(" ", string.Empty))
                    {
                        if (password.Replace(" ",string.Empty) == a.administratorpassword.Replace(" ", string.Empty))
                        {
                            Session.Add(CommonConstant.ADMIN_ID,id);
                            Session.Add(CommonConstant.ADMIN_PASSWORD,password);
                            //Check if Admin's Avatar is exist
                            if (System.IO.File.Exists(
                                HttpContext.Server.MapPath(
                                    "~/Areas/Admin/Content/images/avatar/" + Session[CommonConstant.ADMIN_ID] + ".png")))
                            {
                                Session[CommonConstant.ADMIN_AVATAR] = string.Format(Session[CommonConstant.ADMIN_ID] + ".png");
                            }
                            else
                            {
                                //If not exist show the default avatar
                                Session[CommonConstant.ADMIN_AVATAR] = "default/_Default.png";
                            }
                            return View();
                        }
                    }
                }
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        public ActionResult DBTable()
        {
            if(isLogined() == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }

        //PartialView here
        public ActionResult TicketTable()
        {
            if (isLogined() == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<TicketView> tickets = TicketView.PullTicket(10);
            return PartialView(tickets);
        } 
    }
}