﻿using BuyThis.Models;

namespace BuyThis.Data
{
    public class OrderItems
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Order Order { get; set; }

    }
}
