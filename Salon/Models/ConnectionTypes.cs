
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
    
public partial class ConnectionTypes
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public ConnectionTypes()
    {

        this.Connections = new HashSet<Connections>();

    }


    public int ConnectionTypeId { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<Connections> Connections { get; set; }

}

}
