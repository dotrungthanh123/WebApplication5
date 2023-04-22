using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Retailer
    {
        public int RetailerId { get; set; }

        public int AccountId { get; set; }
        public Account? Account { get; set; }

        public int AdminId { get; set; }
        public Admin? Admin { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime ApproveDate { get; set; }
        public string Name { get; set; }
    }
}