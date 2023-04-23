using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey(nameof(AdminId))]
    public class Admin
    {
        [Key] public int AdminId { get; set; }
        
        [ForeignKey("AccountId")]
        public Account? Account { get; set; }

        public int RetailerId { get; set; }
        public Retailer? Retailer { get; set; }

        public ICollection<Event>? Events { get; set; }

        [Required]
        public float? Salary { get; set; }
        [Required]
        public string? Name { get; set; }    
    }
}
