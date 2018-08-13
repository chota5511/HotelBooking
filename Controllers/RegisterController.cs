using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Update(string id, string name, DateTime birth, string sex, string password, string rpassword)
        {
            HOTELEntities db = new HOTELEntities();
            if (id != "" && password != "" && rpassword == password)
            {
                bool isHaved = false;
                foreach(user u in db.users)
                {
                    if(u.userid.Replace(" ", "") == id)
                    {
                        isHaved = true;
                        break;
                    }
                }
                if(isHaved == false)
                {
                    user tmp = new user();
                    tmp.userid = id;
                    tmp.username = name;
                    tmp.userpassword = password;
                    tmp.userbirth = birth;
                    tmp.usersex = sex;
                    db.users.Add(tmp);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Index", "Home");
        }
    } 
}