using BuyThis.Models;

namespace BuyThis.Data
{
    public class CartItems
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public Cart Cart { get; set; }
    }
}
