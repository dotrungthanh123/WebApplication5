using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey(nameof(EventId), nameof(OrderId))]
    public class OrderDetail
    {
        [ForeignKey("EventId")]
        public Event? Event { get; set; }

        [ForeignKey("OrderId")]
        public int OrderId { get; set; }
        public Order? Order { get; set; }

        public int Quantity { get; set; }
    }
}