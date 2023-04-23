using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Category
    {
        [Key] public int CategoryId { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        public ICollection<Event>? Events { get; set;}
    }
}
