using WebApplication5.Data;

namespace WebApplication5.Models
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly WebApplication5Context _webApplication5DbContext;

        public CustomerRepository(WebApplication5Context webApplication5Context)
        {
            _webApplication5DbContext = webApplication5Context;
        }

        public Customer? GetCustomerByAccountId(int accountId)
        {
            return _webApplication5DbContext.Customers.SingleOrDefault(c => c.AccountId == accountId);
        }
    }
}
