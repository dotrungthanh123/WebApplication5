using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    [PrimaryKey(nameof(AccountId))]
    public class Account
    {
        public int Role { get; set; }
        public Admin? Admin { get; set; }
        public string Name { get; set; }
        public Retailer? Retailer { get; set; }
        public Customer? Customer { get; set; }
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string? GoogleId { get; set; }
    }
}
