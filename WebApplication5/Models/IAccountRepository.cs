namespace WebApplication5.Models
{
    public interface IAccountRepository
    {
        public Account? GetAccountWithUsernameAndPassword(string username, string password);
        public Account? GetAccountWithGoogleId(string googleId);
        public void addAccount(Account account);
    }
}
