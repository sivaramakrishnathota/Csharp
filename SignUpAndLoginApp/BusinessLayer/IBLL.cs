namespace BusinessLayer
{
    public interface IBLL
    {
        string UserLogin(string email, string password);
        string UserRegistration(string email, string password, string userName, string mobileNumber);
        string ChangePassword(string email, string newpassword, string username);
    }
}
