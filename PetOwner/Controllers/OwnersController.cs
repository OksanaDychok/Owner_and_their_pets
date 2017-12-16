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
    public class OwnersController : ApiController
    {
        private PetOwnerContext db = new PetOwnerContext();

        /// <summary>
        /// Get all the owners available
        /// GET: api/Owners
        /// </summary>
        /// <returns>Return all owners with related pets</returns>
        public IQueryable<Owner> GetOwners()
        {
            return db.Owners.Include(p => p.Pets);
        }

        /// <summary>
        /// Return a single owner by id
        /// GET: api/Owners/5
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns>Existing single owner</returns>
        /// <response code="200">if owner found</response>
        /// <response code="404">if owner not found</response>
        [ResponseType(typeof(Owner))]
        public IHttpActionResult GetOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            return Ok(owner);
        }

        /// <summary>
        /// Adds a new owner
        /// POST: api/Owners
        /// </summary>
        /// <param name="owner">Instance of class Owner</param>
        /// <returns>Newly added owner</returns>
        /// <response code="201">if owner created</response>
        /// <response code="400">if input null or invalid</response>
        [ResponseType(typeof(Owner))]
        public IHttpActionResult PostOwner(Owner owner)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Owners.Add(owner);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = owner.Id }, owner);
        }

        /// <summary>
        /// Delete a single owner by id
        /// DELETE: api/Owners/5
        /// </summary>
        /// <param name="id">Owner id</param>
        /// <returns>Successfully delete owner</returns>
        /// <response code="200">if owner found</response>
        /// <response code="404">if owner not found</response>
        [ResponseType(typeof(Owner))]
        public IHttpActionResult DeleteOwner(int id)
        {
            Owner owner = db.Owners.Find(id);
            if (owner == null)
            {
                return NotFound();
            }

            db.Owners.Remove(owner);
            db.SaveChanges();

            return Ok(owner);
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