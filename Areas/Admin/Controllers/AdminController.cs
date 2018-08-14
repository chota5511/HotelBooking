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
                if(a.administratorid.Replace(" ","") == id)
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
                return RedirectToAction("Users", "Admin");
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

        //Search for Administrator: Admin/Admin/SearchAdministrators
        public ActionResult SearchAdministrators(string info)
        {
            if (isLogined() == false || string.IsNullOrEmpty(info) == true)
            {
                return RedirectToAction("Administrators", "Admin");
            }
            List<AdministratorView> administrators = new List<AdministratorView>();
            List<string> keyword = new List<string>();
            keyword = info.Split(' ').ToList();
            foreach (administrator a in db.administrators)
            {
                bool check = false;
                AdministratorView _a = new AdministratorView(a);
                //if any property contains info then add
                foreach (string s in keyword)
                {
                    if (string.Format(
                    _a.ID +
                    _a.Name +
                    _a.Sex +
                    _a.AuthorizationName +
                    a.administratorbirth.ToString()).ToLower().Contains(s.ToLower()))
                    {
                        check = true;
                    }
                }
                if (check == true)
                {
                    administrators.Add(_a);
                }
            }
            return View(administrators);
        }

        public ActionResult Administrators()
        {
            if(isLogined() == true)
            {
                return View(AdministratorView.PullAdministrator(db.administrators.Count()));
            }
            return RedirectToAction("Dashboard","Admin");
        }


        //PartialView here
        public ActionResult PullAuthorizations()
        {
            if (isLogined() == true)
            {
                return PartialView(db.authorizations);
            }
            return RedirectToAction("Dashboard", "Admin");
        }

        //Submit Event
        //Add a user
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

        //Add a Administrator
        public ActionResult AddAdministrator(string ID, string name, string password, string rpassword, DateTime? birth, string sex, int? authorization)
        {
            if (ID == "" || name == "" || password == "" || rpassword == "" || birth.HasValue == false || sex == "" || authorization == null)
            {
                Session[CommonConstant.MESSAGE] = "Enter all the infomation";
            }
            else if (password != rpassword)
            {
                Session[CommonConstant.MESSAGE] = "Password is not match";
            }
            else
            {
                administrator tmp = new administrator();
                tmp.administratorid = ID;
                tmp.administratorname = name;
                tmp.administratorpassword = password;
                tmp.administratorbirth = birth;
                tmp.administratorsex = sex;
                tmp.authorizationid = (int)authorization;
                db.administrators.Add(tmp);
                db.SaveChanges();
                return RedirectToAction("Administrators", "Admin");
            }

            return RedirectToAction("Administrators", "Admin");
        }

        //Edit a user
        public ActionResult EditUser(string ID, string name, string password, string rpassword, DateTime? birth, string sex)
        {
            if (ID != "" || password != "")
            {
                if (name != "" || rpassword != "" || birth.HasValue == true || sex != "")
                {
                    user tmp = new user();
                    tmp = db.users.Find(ID);
                    if(name != "")
                    {
                        tmp.username = name;
                    }
                    if(rpassword != "" && password == rpassword)
                    {
                        tmp.userpassword = password;
                    }
                    if (birth.HasValue == true)
                    {
                        tmp.userbirth = birth;
                    }
                    if(sex != "")
                    {
                        tmp.usersex = sex;
                    }
                    db.Entry(tmp).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Users", "Admin");
            }
            return RedirectToAction("Users", "Admin");
        }

        //Edit a ticket
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

        public ActionResult EditAdministrator(string ID, string name, string password, string rpassword, DateTime? birth, int? authorization, string sex)
        {
            if (ID != "" || password != "")
            {
                if (name != "" || rpassword != "" || birth.HasValue == true || sex != "")
                {
                    administrator tmp = new administrator();
                    tmp = db.administrators.Find(ID);
                    if (name != "")
                    {
                        tmp.administratorname = name;
                    }
                    if (rpassword != "" && password == rpassword)
                    {
                        tmp.administratorpassword = password;
                    }
                    if (birth.HasValue == true)
                    {
                        tmp.administratorbirth = birth;
                    }
                    if (sex != "")
                    {
                        tmp.administratorsex = sex;
                    }
                    if(authorization != null)
                    {
                        tmp.authorizationid = (int)authorization;
                    }
                    db.Entry(tmp).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Administrators", "Admin");
            }
            return RedirectToAction("Administrators", "Admin");
        }

        //Delete a user
        public ActionResult DelUser(string ID)
        {
            if(ID != "")
            {
                user tmp = new user();
                foreach (user u in db.users)
                {
                    if (u.userid.Replace(" ", "") == ID)
                    {
                        tmp = u;
                        break;
                    }
                }
                if (tmp.userid.ToString().Replace(" ", "") != "")
                {
                    db.users.Remove(tmp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Users", "Admin");
        }

        //Delete a Ticket
        public ActionResult DelTicket(int? ID)
        {
            if(ID != null)
            {
                db.tickets.Remove(db.tickets.Find(ID));
                db.SaveChanges();
            }
            return RedirectToAction("Tickets", "Admin");
        }
        //Del a admin account
        public ActionResult DelAdministrator(string ID)
        {
            if (ID != "")
            {
                administrator tmp = new administrator();
                foreach (administrator a in db.administrators)
                {
                    if (a.administratorid.Replace(" ", "") == ID)
                    {
                        tmp = a;
                        break;
                    }
                }
                if (tmp.administratorid.ToString().Replace(" ", "") != "")
                {
                    db.administrators.Remove(tmp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Administrators", "Admin");
        }
    }
}