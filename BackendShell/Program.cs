using System;
using System.Collections.Generic;
using ExampleCodeTest.Enums;
using ExampleCodeTest.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ExampleCodeTest
{
    public class Program
    {
        public static Dictionary<int, Order> Data = new Dictionary<int, Order>();

        public static void Main(string[] args)
        {
            Data.Add(0, new Order
            {
                CustomerName = "Kroger",
                OrderId = 0,
                OrderType = OrderType.Standard,
                CreatedDate = new DateTime(2020, 9, 30),
                CreatedByUserName = "Matt"
            });
            Data.Add(1, new Order
            {
                CustomerName = "Target",
                OrderId = 1,
                OrderType = OrderType.PurchaseOrder,
                CreatedDate = new DateTime(2020, 11, 1),
                CreatedByUserName = "Shay"
            });
            Data.Add(2, new Order
            {
                CustomerName = "Walmart",
                OrderId = 2,
                OrderType = OrderType.ReturnOrder,
                CreatedDate = new DateTime(2020, 10, 19),
                CreatedByUserName = "David"
            });
            Data.Add(3, new Order
            {
                CustomerName = "Aldi",
                OrderId = 3,
                OrderType = OrderType.SaleOrder,
                CreatedDate = new DateTime(2020, 5, 15),
                CreatedByUserName = "Josh"
            });
            Data.Add(4, new Order
            {
                CustomerName = "Meijer",
                OrderId = 4,
                OrderType = OrderType.TransferOrder,
                CreatedDate = new DateTime(2020, 12, 12),
                CreatedByUserName = "Alex"
            });

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}