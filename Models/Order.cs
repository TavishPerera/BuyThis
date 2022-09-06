namespace BuyThis.Data
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        //public int OrderQty { get; set; }
        //public decimal OrderTotal { get; set; }
        public string OrderStatus { get; set; }
        public ICollection<OrderItems> Items { get; set; }
        public User User { get; set; }
    }
}