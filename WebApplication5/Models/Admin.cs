using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    [PrimaryKey(nameof(AdminId))]
    public class Admin
    {
        public int AdminId { get; set; }
        
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public List<Retailer> Retailers { get; } = new List<Retailer>();

        public float Salary { get; set; }
        public string Name { get; set; }    
    }
}
