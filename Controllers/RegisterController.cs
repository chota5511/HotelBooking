using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HotelBooking.Models;

namespace HotelBooking.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Register(string userid, string username, DateTime? userbirth, string MaleOrFemale, string userpassword, string confirmpassword)
        {
            HOTELEntities db = new HOTELEntities();
            user user = new user();
            user.userid = userid;
            user.username = username;
            user.userbirth = userbirth;
            user.usersex = MaleOrFemale;
          
            db.users.Add(user);
            db.SaveChanges();
            return View();
        }
    } 
}