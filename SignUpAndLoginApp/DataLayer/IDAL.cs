using BusinessModel;

namespace DataLayer
{
    public interface IDAL
    {
        string IsValidRegister(string email, string password, string username, string mobileNumber);
        string IsValidLogin(Users userObj);
        string ToChangePassword(string email, string newpassword, string username);
        bool InsertUser(Users userObj);
    }
}
