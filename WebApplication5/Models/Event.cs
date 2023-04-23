using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Event
    {   
        [Key] public int EventId { get; set; }

        [ForeignKey("CategoryId")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("RetailerId")]
        public Retailer? Retailer { get; set; }

        [ForeignKey("AdminId")]
        public Admin? Admin { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public int? Seat { get; set; }
        [Required]
        public float? Price { get; set; }

        [Required]
        public DateTime ApproveDate { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
