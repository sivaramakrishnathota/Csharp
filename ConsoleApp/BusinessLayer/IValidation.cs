using BusinessModel;

namespace BusinessLayer
{
    public interface IValidation
    {
        public bool IsValidUserName(string userName);
        public bool IsValidPassword(string password);
        public bool IsVaidMobileNumber(string mobileNo);
        public bool IsValidUserEmail(string userEmail);
        public bool IsRegistered(User userObj);
        public bool ToChangePassword(User userObj, string newPassword);
    }

}
