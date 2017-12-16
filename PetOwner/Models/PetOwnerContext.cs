using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetOwner.Models
{
    public class PetOwnerContext: DbContext
    {
        public PetOwnerContext(): base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Owner> Owners { get; set; }
    }
}