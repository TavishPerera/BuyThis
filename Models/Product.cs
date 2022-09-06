namespace BuyThis.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDescription { get; set; }
        public int ProductStock { get; set; }
        public string ProductCategory { get; set; }
    }
}
