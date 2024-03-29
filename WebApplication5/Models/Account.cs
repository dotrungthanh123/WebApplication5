﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication5.Models
{
    public class Account
    {
        public int Role { get; set; }
        public Admin? Admin { get; set; }
        public Retailer? Retailer { get; set; }
        public Customer? Customer { get; set; }
        [Key]
        public int AccountId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; } 
    }
}
