using DataLayer;
using BusinessModel;
namespace BusinessLayer
{
    public class BLLAuthentication : IBLL
    {
        public string UserLogin(string email, string password)
        {
            DALFactory dALFactoryObj = new DALFactory();
            IDAL dALObj = dALFactoryObj.GetDALAuthenticationObj();

            Users userObj = new Users();
            userObj.Email = email;
            userObj.Password = password;
            if (dALObj.IsValidLogin(userObj) == "false")
            {
                return "false";
            }
            else if (dALObj.IsValidLogin(userObj) != "false" && dALObj.IsValidLogin(userObj) != "true")
            {
                return dALObj.IsValidLogin(userObj);
            }
            return "true";
        }

        public string UserRegistration(string email, string password, string userName, string mobileNumber)
        {
            DALFactory dALFactoryObj = new DALFactory();
            IDAL dALObj = dALFactoryObj.GetDALAuthenticationObj();

            Users userObj = new Users();
            userObj.Email = email;
            userObj.Password = password;
            userObj.UserName = userName;
            userObj.MobileNumber = mobileNumber;

            if (dALObj.IsValidRegister(email, password, userName, mobileNumber) == "false")
            {
                if (dALObj.InsertUser(userObj) == false)
                {
                    return "false";
                }
                return "true";
            }
            else if (dALObj.IsValidRegister(email, password, userName, mobileNumber) != "false" && dALObj.IsValidRegister(email, password, userName, mobileNumber) != "true")
            {
                return dALObj.IsValidRegister(email, password, userName, mobileNumber);
            }
            else
            {
                return "false";
            }

        }
        public string ChangePassword(string email, string newpassword, string username)
        {
            //DAL dALObj=new DAL();
            DALFactory dALFactoryObj = new DALFactory();
            IDAL dALObj = dALFactoryObj.GetDALAuthenticationObj();
            if (dALObj.ToChangePassword(email, username, newpassword) == "true")
            {
                return "true";
            }
            else if (dALObj.ToChangePassword(email, username, newpassword) != "true" && dALObj.ToChangePassword(email, username, newpassword) != "false")
            {
                return dALObj.ToChangePassword(email, username, newpassword);
            }
            return "false";
        }
    }
}
