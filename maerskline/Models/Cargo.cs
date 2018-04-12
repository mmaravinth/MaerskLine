//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace maerskline.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Cargo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Cargo()
        {
            this.Shippments = new HashSet<Shippment>();
        }
    
        public int cargoID { get; set; }
        [Required]
        public Nullable<int> volume { get; set; }
        [Required]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Use numbers only please")]
        public Nullable<int> weight { get; set; }
        
        public Nullable<int> warehouseID { get; set; }
        
        public Nullable<int> customerID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shippment> Shippments { get; set; }
    }
}
