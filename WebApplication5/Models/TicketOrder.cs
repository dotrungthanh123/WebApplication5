using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class TicketOrder
    {
        [Key] public int OrderId { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public DateTime? BuyDate { get; set; }
    }
}
