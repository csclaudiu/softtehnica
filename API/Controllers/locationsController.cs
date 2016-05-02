﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DATA;
using MODELS.Dto;

namespace API.Controllers
{
    public class locationsController : ApiController
    {
        private softtehnicaEntities db = new softtehnicaEntities();

        // GET: api/locations
        public List<LocationDto> Getlocations()
        {
            return db.locations.Select(l=> new LocationDto() { id = l.id, location_name = l.location_name }).ToList();
        }

        // GET: api/locations/5
        [ResponseType(typeof(location))]
        public IHttpActionResult Getlocation(int id)
        {
            location location = db.locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            return Ok(location);
        }

        // PUT: api/locations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putlocation(int id, location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != location.id)
            {
                return BadRequest();
            }

            db.Entry(location).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!locationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/locations
        [ResponseType(typeof(location))]
        public IHttpActionResult Postlocation(location location)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.locations.Add(location);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = location.id }, location);
        }

        // DELETE: api/locations/5
        [ResponseType(typeof(location))]
        public IHttpActionResult Deletelocation(int id)
        {
            location location = db.locations.Find(id);
            if (location == null)
            {
                return NotFound();
            }

            db.locations.Remove(location);
            db.SaveChanges();

            return Ok(location);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool locationExists(int id)
        {
            return db.locations.Count(e => e.id == id) > 0;
        }
    }
}