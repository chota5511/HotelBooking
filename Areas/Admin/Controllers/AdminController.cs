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

        //Login process
        public bool isLoginSucess(string id,string password)
        {
            //Check user's id and password
            foreach(administrator a in db.administrators)
            {
                if(a.administratorpassword.Replace(" ","") == id)
                {
                    if(a.administratorpassword.Replace(" ","") == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //Login Admin: Admin/Admin/Login
        public ActionResult Login(string id, string password)
        {
            if (isLogined() == true)
            {
                return RedirectToAction("Index", "Admin");
            }
            else if(id != null || password != null)
            {
                if (isLoginSucess(id, password) == true)
                {
                    Session[CommonConstant.MESSAGE] = null;
                    Session.Add(CommonConstant.ADMIN_ID, id);
                    Session.Add(CommonConstant.ADMIN_PASSWORD, password);
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
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    Session[CommonConstant.MESSAGE] = "UserID or Password is not match.";
                }
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
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        //Ticket page: Admin/Admin/Ticket

        //Search for ticket: Admin/Admin/SearchTicket
        public ActionResult SearchTicket(string info)
        {
            if (isLogined() == false || string.IsNullOrEmpty(info) == true)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<TicketView> tickets = new List<TicketView>();
            foreach (ticket t in db.tickets)
            {
                TicketView tmp = new TicketView(t);
                //if any property contains info then add
                if (string.Format(
                    tmp.ID.ToString() +
                    tmp.UserID + 
                    tmp.UserName + 
                    tmp.HotelID + 
                    tmp.HotelName + 
                    tmp.Date.ToString() +
                    tmp.DateEnd.ToString() +
                    tmp.DateStart.ToString()).ToLower().Contains(info.ToLower()))
                {
                    tickets.Add(tmp);
                }
            }
            return View(tickets);
        }
        public ActionResult Ticket()
        {
            if (isLogined() == false)
            {
                return RedirectToAction("Index", "Admin");
            }
            List<TicketView> tickets = TicketView.PullTicket(db.tickets.Count());
            return View(tickets);
        }

        //PartialView here

    }
}