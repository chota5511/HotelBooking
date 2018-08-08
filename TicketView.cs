using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HotelBooking.Models;

namespace HotelBooking
{
    public class TicketView
    {
        private int id;
        private string date;
        private string dateStart;
        private string dateEnd;
        private int hotelID;
        private string hotelName;
        private string userID;
        private string userName;

        //Getter and Setter
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        public string DateStart
        {
            get { return dateStart; }
            set { dateStart = value; }
        }
        public string DateEnd
        {
            get { return dateEnd; }
            set { dateEnd = value; }
        }
        public int HotelID
        {
            get { return hotelID ; }
            set { hotelID = value; }
        }
        public string HotelName
        {
            get { return hotelName; }
            set { hotelName = value; }
        }
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }



        //Constructer
        public TicketView(ticket ticket)
        {
            HOTELEntities db = new HOTELEntities();
            id = ticket.ticketid;
            date = ticket.ticketdate.ToShortDateString();
            dateStart = ticket.datestart.ToShortDateString();
            dateEnd = ticket.expectdateend.ToString().Replace("12:00:00 AM",string.Empty);
            hotelID = ticket.hotelid;
            hotelName = db.hotels.Find(ticket.hotelid).hotelname;
            userID = ticket.userid;
            userName = db.users.Find(ticket.userid).username;
        }

        //Static Method (Function)
        /// <summary>
        /// Get ticked back from database and insert to a List<TicketView>
        /// </summary>
        /// <returns></returns>
        public static List<TicketView> PullTicket(int count)
        {
            HOTELEntities db = new HOTELEntities();
            List<ticket> tmp = db.tickets.OrderByDescending(t => t.datestart).Take(count).ToList();
            List<TicketView> tickets = new List<TicketView>();
            foreach (ticket t in tmp)
            {
                TicketView ticketView = new TicketView(t);
                tickets.Add(ticketView);
            }
            return tickets;
        }
        
    }
}