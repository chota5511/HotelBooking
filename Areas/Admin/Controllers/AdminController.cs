using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
                return RedirectToAction("Dashboard", "Admin");
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
                    return RedirectToAction("Dashboard", "Admin");
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
            return RedirectToAction("Dashboard", "Admin");
        }

        // GET: Admin/Admin
        public ActionResult Dashboard()
        {
            //Check if Session is available
            if(isLogined() == false)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        //Ticket page: Admin/Admin/Tickets
        public ActionResult Tickets()
        {
            if (isLogined() == false)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            List<TicketView> tickets = TicketView.PullTicket(db.tickets.Count());
            return View(tickets);
        }

        //Search for ticket: Admin/Admin/SearchTickets
        public ActionResult SearchTickets(string info)
        {
            if (isLogined() == false || string.IsNullOrEmpty(info) == true)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            List<TicketView> tickets = new List<TicketView>();
            List<string> keyword = new List<string>();
            keyword = info.Split(' ').ToList();
            foreach (ticket t in db.tickets)
            {
                TicketView tmp = new TicketView(t);
                bool check = false;
                //if any property contains info then add
                foreach (string s in keyword)
                {
                    if (string.Format(
                    tmp.ID.ToString() +
                    tmp.UserID +
                    tmp.UserName +
                    tmp.HotelID +
                    tmp.HotelName +
                    tmp.Date.ToString() +
                    tmp.DateEnd.ToString() +
                    tmp.DateStart.ToString()).ToLower().Contains(s.ToLower()))
                    {
                        check = true;
                    }
                }
                if(check == true)
                {
                    tickets.Add(tmp);
                }
            }
            return View(tickets);
        }

        //User page: Admin/Admin/Users
        public ActionResult Users()
        {
            if(isLogined() == false)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return View(db.users);
        }

        //Search for User: Admin/Admin/SearchUsers
        public ActionResult SearchUsers(string info)
        {
            if (isLogined() == false || string.IsNullOrEmpty(info) == true)
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            List<user> users = new List<user>();
            List<string> keyword = new List<string>();
            keyword = info.Split(' ').ToList();
            foreach (user u in db.users)
            {
                bool check = false;
                //if any property contains info then add
                foreach (string s in keyword)
                {
                    if (string.Format(
                    u.userid +
                    u.username +
                    u.usersex +
                    u.userbirth.ToString()).ToLower().Contains(s.ToLower()))
                    {
                        check = true;
                    }
                }
                if (check == true)
                {
                    users.Add(u);
                }
            }
            return View(users);
        }


        //PartialView here


        //Submit Event
        public ActionResult AddUser(string ID,string name,string password,string rpassword,DateTime? birth,string sex)
        {
            if(ID == "" || name == "" || password == "" || rpassword == "" || birth.HasValue == false || sex == "")
            {
                Session[CommonConstant.MESSAGE] = "Enter all the infomation";
            }
            else if(password != rpassword)
            {
                Session[CommonConstant.MESSAGE] = "Password is not match";
            }
            else
            {
                user tmp = new user();
                tmp.userid = ID;
                tmp.username = name;
                tmp.userpassword = password;
                tmp.userbirth = birth;
                tmp.usersex = sex;
                db.users.Add(tmp);
                db.SaveChanges();
                return RedirectToAction("Users", "Admin");
            }
            
            return RedirectToAction("Users", "Admin");
        }
        //Edit user
        public ActionResult EditUser(string ID, string name, string password, string rpassword, DateTime? birth, string sex)
        {
            if (ID == "" || name == "" || password == "" || birth.HasValue == false || sex == "")
            {
                Session[CommonConstant.MESSAGE] = "Enter all the infomation";
            }
            else if(rpassword == "")
            {
                user tmp = new user();
                tmp.userid = ID;
                tmp.username = name;
                tmp.userpassword = password;
                tmp.userbirth = birth;
                tmp.usersex = sex;
                db.Entry(tmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Users", "Admin");
            }
            else if (password != rpassword)
            {
                Session[CommonConstant.MESSAGE] = "Password is not match";
            }
            else
            {
                user tmp = new user();
                tmp.userid = ID;
                tmp.username = name;
                tmp.userpassword = password;
                tmp.userbirth = birth;
                tmp.usersex = sex;
                db.Entry(tmp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Users", "Admin");
            }

            return RedirectToAction("Users", "Admin");
        }
        public ActionResult EditTicket(int? ID, DateTime? date, DateTime? datestart,DateTime? dateend)
        {
            if (ID != null)
            {
                if (date.HasValue == true || datestart.HasValue == true || dateend.HasValue == true)
                {
                    ticket tmp = new ticket();
                    tmp = db.tickets.Find(ID);
                    if (date.HasValue == true)
                    {
                        tmp.ticketdate = (DateTime)date;

                    }
                    if (datestart.HasValue == true)
                    {
                        tmp.datestart = (DateTime)datestart;

                    }
                    if (dateend.HasValue == true)
                    {
                        tmp.expectdateend = dateend;
                    }
                    db.Entry(tmp).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Tickets", "Admin");
            }
            return RedirectToAction("Tickets", "Admin");
        }


    }
}