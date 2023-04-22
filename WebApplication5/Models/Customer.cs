using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }

        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account Account { get; set; }

        public List<TicketOrder> ticketOrders { get; } = new List<TicketOrder>();

        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }   
    }
}
