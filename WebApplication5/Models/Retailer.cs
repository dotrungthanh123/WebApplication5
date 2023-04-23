using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication5.Models
{
    public class Retailer
    {
        public int RetailerId { get; set; }

        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }
        public Account? Account { get; set; }

        [ForeignKey(nameof(Admin))]
        public int AdminId { get; set; }
        public Admin? Admin { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime ApproveDate { get; set; }
    }
}