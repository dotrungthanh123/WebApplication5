using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Event
    {
        public int EventId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("Retailer")]
        public int RetailerId { get; set; }
        public Retailer? Retailer { get; set; }

        [ForeignKey("Admin")]
        public int AdminId { get; set; }
        public Admin? Admin { get; set; }

        public string Name { get; set; }
        public int Seat { get; set; }
        public float Price { get; set; }
        public DateTime? ApproveDate { get; set; }
        public DateTime StartDate { get; set; }
        public string Address { get; set; }
    }
}
