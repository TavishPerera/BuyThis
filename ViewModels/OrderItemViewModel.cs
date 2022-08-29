using BuyThis.Data;
using BuyThis.Models;
using System.ComponentModel.DataAnnotations;

namespace BuyThis.ViewModels
{
    public class OrderItemViewModel
    {
        public int OVId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public int ProductId { get; set; }

    }
}
