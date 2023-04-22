using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey(nameof(EventId), nameof(OrderId))]
    public class OrderDetail
    {
        [ForeignKey("Event")]
        public int EventId { get; set; }
        public Event? Event { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public TicketOrder? TicketOrder { get; set; }

        public int Quantity { get; set; }
    }
}