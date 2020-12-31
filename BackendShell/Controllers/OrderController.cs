using System;
using System.Collections.Generic;
using System.Linq;
using ExampleCodeTest.Enums;
using ExampleCodeTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace ExampleCodeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Projections.Order> Get()
        {
            var data = Program.Data.Values.Select(o => new Projections.Order(o));
            return data;
        }

        [HttpGet]
        [Route("search")]
        public IEnumerable<Projections.Order> Search([FromQuery] OrderType? type, [FromQuery] string customerName)
        {
            Func<Order, bool> predicate = o =>
                (type.HasValue && o.OrderType == type)
                || (string.IsNullOrWhiteSpace(customerName) && o.CustomerName == customerName);
            var data = Program.Data.Values.Where(predicate).Select(o => new Projections.Order(o));
            return data;
        }

        [HttpPost]
        public int Create(Order newOrder)
        {
            if (newOrder.OrderId == 0 || Program.Data.ContainsKey(newOrder.OrderId))
            {
                newOrder.OrderId = Program.Data.Values.Max(o => o.OrderId) + 1;
            }

            if (newOrder.CreatedDate == DateTime.MinValue)
            {
                newOrder.CreatedDate = DateTime.Now;
            }

            Program.Data.Add(newOrder.OrderId, newOrder);
            // creates and order and returns id's ID
            return newOrder.OrderId;
        }

        //create a DELETE endpoint that removes and Order
        [HttpDelete]
        [Route("{id}")]
        public bool Delete(int id)
        {
            return Program.Data.Remove(id);
        }
    }
}