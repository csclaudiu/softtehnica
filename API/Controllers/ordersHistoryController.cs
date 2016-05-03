using AutoMapper;
using DATA;
using Microsoft.AspNet.Identity;
using MODELS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ordersHistoryController : ApiController
    {
        private softtehnicaEntities db = new softtehnicaEntities();

        // not used
        [HttpGet]
        public List<OrderHistoryDto> showHistory()
        {
            var OperatorID = User.Identity.GetUserId<int>();

            var dbquery = db.orders.Where(o => o.operatorid == OperatorID).OrderByDescending(o => o.date).ToList();

            var orders = dbquery.Select(o => new OrderHistoryDto()
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
                }).ToList(),
                total = db.v_OrderProducts.Where(vop => vop.orderid == o.id).Sum(s=>s.price)
            }).ToList();

            return orders;
        }

        [HttpGet]
        public List<OrderHistoryDto> showHistoryLocation(int id)
        {
            var OperatorID = User.Identity.GetUserId<int>();

            var dbquery = db.orders.Where(o => o.locationid == id && o.operatorid == OperatorID).OrderByDescending(o => o.date).ToList();

            var orders = dbquery.Select(o => new OrderHistoryDto()
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
                }).ToList(),
                total = db.v_OrderProducts.Where(vop => vop.orderid == o.id).Sum(s => s.price)
            }).ToList();

            return orders;
        }
    }
}
