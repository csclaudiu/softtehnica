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
using Microsoft.AspNet.Identity;

namespace API.Controllers
{
    [Authorize]
    public class ordersController : ApiController
    {
        private softtehnicaEntities db = new softtehnicaEntities();

        // GET: api/orders
        public List<OrderDto> Getorders()
        {
            var OperatorID = User.Identity.GetUserId<int>();

            var dbquery = db.orders.Where(o => o.operatorid == OperatorID).ToList();

            var orders = dbquery.Select(o => new OrderDto()
            {
                client = Mapper.Map<ClientDto>(o.client),
                comment = o.comment,
                date = o.date,
                location = Mapper.Map<LocationDto>(o.location),
                orderitems = db.v_OrderProducts.Where(vop => vop.orderid == o.id).Select(op => new ProductDto()
                {
                    id = op.productid,
                    name = op.name,
                    price = op.price
                }).ToList()
            }).ToList();

            return orders;
        }


        // GET: api/orders/5
        [ResponseType(typeof(order))]
        public IHttpActionResult Getorder(int id)
        {
            order order = db.orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        // PUT: api/orders/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putorder(int id, order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != order.id)
            {
                return BadRequest();
            }

            db.Entry(order).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!orderExists(id))
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

        // POST: api/orders
        [ResponseType(typeof(OrderDto))]
        public IHttpActionResult Postorder(OrderDto order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // var dbOrder = Mapper.Map<order>(order);


            var OperatorID = User.Identity.GetUserId<int>();

            var dbOrder = new order()
            {
                clientid = order.client.id,
                locationid = order.location.id,
                operatorid = OperatorID,
                date = DateTime.Now
            };
            foreach(var orderProduct in order.orderitems)
            {
                dbOrder.orderitems.Add(new orderitem()
                {
                    productid = orderProduct.id
                });
            }

            db.orders.Add(dbOrder);
            db.SaveChanges();

            order.id = dbOrder.id;

            return CreatedAtRoute("DefaultApi", new { id = order.id }, order);
        }

        // DELETE: api/orders/5
        [ResponseType(typeof(order))]
        public IHttpActionResult Deleteorder(int id)
        {
            order order = db.orders.Find(id);
            if (order == null)
            {
                return NotFound();
            }

            db.orders.Remove(order);
            db.SaveChanges();

            return Ok(order);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool orderExists(int id)
        {
            return db.orders.Count(e => e.id == id) > 0;
        }
    }
}