namespace ExampleCodeTest.Projections
{
    public class Order
    {
        public Order(Models.Order o)
        {
            OrderId = o.OrderId;
            CreatedByUserName = o.CreatedByUserName;
            CustomerName = o.CustomerName;
            CreatedDate = o.CreatedDate.ToLongDateString();
            OrderType = o.OrderType.ToString();
        }

        public int OrderId { get; set; }
        public string OrderType { get; set; }
        public string CustomerName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedByUserName { get; set; }
    }
}