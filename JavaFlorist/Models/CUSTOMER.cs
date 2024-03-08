//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JavaFlorist.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.CARTs = new HashSet<CART>();
            this.ORDERs = new HashSet<ORDER>();
        }
    
        public int CUSTID { get; set; }
        [Required(ErrorMessage ="Don't leave this field empty")]
        public string FNAME { get; set; }

        [Required(ErrorMessage = "Don't leave this field empty")]
        public string LNAME { get; set; }

        [Required(ErrorMessage = "Don't leave this field empty")]
        public string PASSWORD { get; set; }

        [Required(ErrorMessage = "Don't leave this field empty")]
        public string DOB { get; set; }
        public string GENDER { get; set; }

        [Required(ErrorMessage = "Don't leave this field empty")]
        public string PNO { get; set; }

        [Required(ErrorMessage = "Don't leave this field empty")]
        public string ADDRESS { get; set; }
        public string ROLE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CARTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERs { get; set; }
    }
}