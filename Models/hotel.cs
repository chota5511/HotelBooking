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
    
    public partial class hotel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public hotel()
        {
            this.tickets = new HashSet<ticket>();
        }
    
        public int hotelid { get; set; }
        public string hotelname { get; set; }
        public string addressnumber { get; set; }
        public int streetid { get; set; }
        public int districtid { get; set; }
        public int cityid { get; set; }
        public decimal unitprice { get; set; }
        public decimal phonenumber { get; set; }
    
        public virtual city city { get; set; }
        public virtual district district { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ticket> tickets { get; set; }
        public virtual street street { get; set; }
    }
}
