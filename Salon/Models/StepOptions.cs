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
    
    public partial class StepOptions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StepOptions()
        {
            this.VisitTasks = new HashSet<VisitTasks>();
        }
    
        public int StepOptionId { get; set; }
        public int StepId { get; set; }
        public int Position { get; set; }
        public string Option { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; }
    
        public virtual Steps Steps { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VisitTasks> VisitTasks { get; set; }
    }
}
