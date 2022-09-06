using BuyThis.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BuyThis.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        [Required]
        public int OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
        //[Required]
        //public int OrderQty { get; set; }
        //[Required]
        //public decimal OrderTotal { get; set; }
        public ICollection<OrderItemViewModel> Items { get; set; }
    }
}
