//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelBooking.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class bill
    {
        public int billid { get; set; }
        public System.DateTime billdate { get; set; }
        public System.DateTime dateend { get; set; }
        public int ticketid { get; set; }
        public string administratorid { get; set; }
    
        public virtual administrator administrator { get; set; }
        public virtual ticket ticket { get; set; }
    }
}
