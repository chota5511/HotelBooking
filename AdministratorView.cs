using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.Models;

namespace HotelBooking
{
    public class AdministratorView
    {
        private string id;
        private string name;
        private string birth;
        private string sex;
        private int authorizationID;
        private string password;
        private string authorizationName;

        //Getter and Setter
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Birth
        {
            get { return birth; }
            set { birth = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        public int AuthorizationID
        {
            get { return authorizationID; }
            set { authorizationID = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public string AuthorizationName
        {
            get { return authorizationName; }
            set { authorizationName = value; }
        }

        //Constructer
        public AdministratorView(administrator administrator)
        {
            HOTELEntities db = new HOTELEntities();
            id = administrator.administratorid.Replace(" ","");
            name = administrator.administratorname;
            birth = administrator.administratorbirth.ToString().Replace("12:00:00 AM",string.Empty);
            sex = administrator.administratorsex;
            authorizationID = administrator.authorizationid;
            password = administrator.administratorpassword;
            authorizationName = db.authorizations.Find(administrator.authorizationid).authorizationname;
        }

        //Static Method (Function)
        /// <summary>
        /// Get administrator back from database and insert to a List<AdministratorView>
        /// </summary>
        /// <returns></returns>
        public static List<AdministratorView> PullAdministrator(int count)
        {
            HOTELEntities db = new HOTELEntities();
            List<administrator> tmp = db.administrators.ToList();
            List<AdministratorView> administrators = new List<AdministratorView>();
            foreach (administrator a in tmp)
            {
                AdministratorView ticketView = new AdministratorView(a);
                administrators.Add(ticketView);
            }
            return administrators;
        }
    }
}