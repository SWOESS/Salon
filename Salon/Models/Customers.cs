
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace Salon.Models
{

using System;
    using System.Collections.Generic;
    
    public partial class Customers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customers()
        {
            this.Connections = new HashSet<Connections>();
            this.Visits = new HashSet<Visits>();
        }
    
        public int CustomerId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Street { get; set; }
        public bool isActive { get; set; }
        public string Description { get; set; }
        public bool allowImages { get; set; }
        public bool allowSensitive { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime Modified { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime Created { get; set; }
        public int GenderID { get; set; }
        public Nullable<int> CityId { get; set; }
    
        public virtual AspNetUsers AspNetUsers { get; set; }
        public virtual AspNetUsers AspNetUsers1 { get; set; }
        public virtual Cities Cities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Connections> Connections { get; set; }
        public virtual Genders Genders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Visits> Visits { get; set; }
    }
}
