namespace WebApplication5.Models
{
    public interface ICustomerRepository
    {
        public Customer? GetCustomerByAccountId(int accountId);
    }
}
