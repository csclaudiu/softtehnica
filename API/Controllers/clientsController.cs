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
using DATA;
using MODELS.Dto;
using AutoMapper;

namespace API.Controllers
{
    public class clientsController : ApiController
    {
        private softtehnicaEntities db = new softtehnicaEntities();

        public clientsController()
        {
            
        }

        // GET: api/clients
        public List<ClientDto> Getclients()
        {
            return db.clients.Select(p => new ClientDto() { id = p.id, firstname = p.firstname, lastname = p.lastname, email = p.email }).ToList();
        }

        // GET: api/clients/5
        [ResponseType(typeof(client))]
        public IHttpActionResult Getclient(int id)
        {
            client client = db.clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            return Ok(client);
        }

        // PUT: api/clients/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putclient(int id, client client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != client.id)
            {
                return BadRequest();
            }

            db.Entry(client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!clientExists(id))
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

        // POST: api/clients
        [ResponseType(typeof(ClientDto))]
        public IHttpActionResult Postclient(ClientDto client)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbClient = Mapper.Map<client>(client);

            db.clients.Add(dbClient);
            db.SaveChanges();

            client.id = dbClient.id;

            return CreatedAtRoute("DefaultApi", new { id = client.id }, client);
        }

        // DELETE: api/clients/5
        [ResponseType(typeof(client))]
        public IHttpActionResult Deleteclient(int id)
        {
            client client = db.clients.Find(id);
            if (client == null)
            {
                return NotFound();
            }

            db.clients.Remove(client);
            db.SaveChanges();

            return Ok(client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool clientExists(int id)
        {
            return db.clients.Count(e => e.id == id) > 0;
        }
    }
}