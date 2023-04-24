using Microsoft.CodeAnalysis.Elfie.Extensions;
using Microsoft.EntityFrameworkCore;
using WebApplication5.Data;

namespace WebApplication5.Models
{
    public class AccountRepository : IAccountRepository
    {
        private readonly WebApplication5Context _webApplication5DbContext;

        public AccountRepository(WebApplication5Context webApplication5Context)
        {
            _webApplication5DbContext = webApplication5Context;
        }

        public void addAccount(Account account)
        {
            _webApplication5DbContext.Add(account);
            _webApplication5DbContext.SaveChanges();
        }

        public Account? GetAccountWithGoogleId(string googleId)
        {
            var temp = _webApplication5DbContext.Accounts.SingleOrDefault(c => c.GoogleId == googleId);
            if (temp == null)
            {
                Console.Write(1);
            }
            return temp;
        }

        public Account? GetAccountWithUsernameAndPassword(string username, string password)
        {
            return _webApplication5DbContext.Accounts.SingleOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
