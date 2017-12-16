using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetOwner.Models
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int? OwnerId { get; set; }
        public virtual Owner Owner { get; set; }
    }
}