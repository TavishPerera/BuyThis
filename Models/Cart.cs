namespace BuyThis.Data
{
    public class Cart
    {
        public int CartId { get; set; }
        public int CartNumber { get; set; }
        public int CartQty { get; set; }
        public decimal CartTotal { get; set; }
        public string CartName { get; set; }
        public ICollection<CartItems> Items { get; set; }
        //public User User { get; set; }

        public int UserID { get; set; }
        
    }
}
