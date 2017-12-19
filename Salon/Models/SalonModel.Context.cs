﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Salon.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using System.Data.Entity.Core.Objects;
using System.Linq;


public partial class SalonEntities : DbContext
{
    public SalonEntities()
        : base("name=SalonEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

    public virtual DbSet<Cities> Cities { get; set; }

    public virtual DbSet<Connections> Connections { get; set; }

    public virtual DbSet<ConnectionTypes> ConnectionTypes { get; set; }

    public virtual DbSet<Countries> Countries { get; set; }

    public virtual DbSet<Customers> Customers { get; set; }

    public virtual DbSet<Pictures> Pictures { get; set; }

    public virtual DbSet<StepOptions> StepOptions { get; set; }

    public virtual DbSet<Steps> Steps { get; set; }

    public virtual DbSet<Treatments> Treatments { get; set; }

    public virtual DbSet<TreatmentSteps> TreatmentSteps { get; set; }

    public virtual DbSet<Visits> Visits { get; set; }

    public virtual DbSet<VisitTasks> VisitTasks { get; set; }

    public virtual DbSet<Genders> Genders { get; set; }


    public virtual int AnonymizeCustomerByID(Nullable<int> customerID)
    {

        var customerIDParameter = customerID.HasValue ?
            new ObjectParameter("CustomerID", customerID) :
            new ObjectParameter("CustomerID", typeof(int));


        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AnonymizeCustomerByID", customerIDParameter);
    }


    public virtual ObjectResult<Nullable<int>> AnonymizeCustomerByDays()
    {

        return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<int>>("AnonymizeCustomerByDays");
    }

}

}
