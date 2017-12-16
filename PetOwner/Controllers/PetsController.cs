using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PetOwner.Models;

namespace PetOwner.Controllers
{
    public class PetsController : ApiController
    {
        private PetOwnerContext db = new PetOwnerContext();

        /// <summary>
        /// Return pets by their owner id
        /// GET: api/Pets/5
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns>Owner pets list</returns>
        public IQueryable<Pet> GetPets(int id)
        {
            return db.Pets.Where(o=>o.OwnerId == id);
        }

        /// <summary>
        /// Adds a new pet
        /// POST: api/Pets
        /// </summary>
        /// <param name="pet">Instance of class Pet</param>
        /// <returns>Newly added pet</returns>
        /// <response code="201">if pet created</response>
        /// <response code="400">if input null or invalid</response>        
        [ResponseType(typeof(Pet))]
        public IHttpActionResult PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            db.Pets.Add(pet);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

        /// <summary>
        /// Delete a single pet by id
        /// DELETE: api/Pets/5
        /// </summary>
        /// <param name="id">Pet id</param>
        /// <returns>Successfully delete pet</returns>
        /// <response code="200">if pet found</response>
        /// <response code="404">if pet not found</response>        
        [ResponseType(typeof(Pet))]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return NotFound();
            }

            db.Pets.Remove(pet);
            db.SaveChanges();

            return Ok(pet);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <param name="disposing">
        /// Dispose(bool disposing) executes in two distinct scenarios.
        /// If disposing equals true, the method has been called directly
        /// or indirectly by a user's code. Managed and unmanaged resources
        /// can be disposed.
        /// If disposing equals false, the method has been called by the
        /// runtime from inside the finalizer and you should not reference
        /// other objects. Only unmanaged resources can be disposed.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}