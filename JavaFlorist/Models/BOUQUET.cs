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
    
    public partial class BOUQUET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BOUQUET()
        {
            this.CARTs = new HashSet<CART>();
        }
    
        public int BOUQUETID { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public string DESCRIPTION { get; set; }
        public string IMG { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CART> CARTs { get; set; }
    }
}