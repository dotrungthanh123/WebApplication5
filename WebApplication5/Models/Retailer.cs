using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Retailer
    {
        [Key] public int RetailerId { get; set; }

        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public int AdminId { get; set; }
        public Admin? Admin { get; set; }

        [Required]
        public string? Phone { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public DateTime ApproveDate { get; set; }
        [Required]
        public string? Name { get; set; }

        public ICollection<Event>? Events { get; set; }
            
    }
}