using BusinessModel;
using DataLayer;
using System.Text.RegularExpressions;

namespace BusinessLayer
{
    /// <summary>
    /// In this class it has the validation methods for user_name,password,email,mobile_number.
    /// </summary>
    internal class BALValidations : IValidation
    {
        /// <summary>
        /// checks the username is valid or not.
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool IsValidUserName(string userName)
        {
            if (userName.Length > 6 && userName != string.Empty)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// to check valid password or not.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidPassword(string password)
        {
            string pattern = Literals.passwordCheck;
            Regex regex = new Regex(pattern);
            Match match = regex.Match(password);
            return match.Success;
        }

        /// <summary>
        /// to check valid mobile_number or not.
        /// </summary>
        /// <param name="mobileNo"></param>
        /// <returns></returns>
        public bool IsVaidMobileNumber(string mobileNo)
        {
            string pattern = Literals.emailCheck;
            Regex regex = new Regex(pattern);
            Match match = regex.Match(mobileNo);
            // bool isValid = Regex.Match(mobileNo, @"\d{10}").Success;
            return match.Success;
        }

        /// <summary>
        /// to check valid email or not.
        /// </summary>
        /// <param name="userEmail"></param>
        /// <returns></returns>
        public bool IsValidUserEmail(string userEmail)
        {
            string pattern = Literals.mobileNumberCheck;
            Regex regex = new Regex(pattern);
            Match match = regex.Match(userEmail);
            return match.Success;
        }

        /// <summary>
        /// it check if it is already exist in the data then it can't be registered.
        /// </summary>
        /// <param name="userObj"></param>
        /// <returns></returns>
        public bool IsRegistered(User userObj)
        {
            DALFactory DALFactoryObj = new DALFactory();
            IDAL DALObj = DALFactoryObj.GetDALAuthenticationObj();
            bool isValid = DALObj.IsValidRegistration(userObj);
            if (isValid)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// in this method it is change the password if the user name exist in the data.
        /// </summary>
        /// <param name="userObj"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        public bool ToChangePassword(User userObj, string newPassword)
        {
            DALFactory DALFactoryObj = new DALFactory();
            IDAL DALObj = DALFactoryObj.GetDALAuthenticationObj();
            bool isValid = DALObj.ChangePassword(userObj, newPassword);
            if (isValid)
            {
                return true;
            }
            return false;
        }
    }
}