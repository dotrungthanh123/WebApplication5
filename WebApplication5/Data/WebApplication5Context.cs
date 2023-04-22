using Microsoft.EntityFrameworkCore;
using WebApplication5.Models;

namespace WebApplication5.Data
{
    public class WebApplication5Context : DbContext
    {
        public WebApplication5Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Retailer> Retailers { get; set; }
    }
}