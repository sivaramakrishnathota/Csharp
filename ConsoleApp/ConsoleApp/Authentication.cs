using BusinessLayer;
using BusinessModel;

namespace ConsoleApp
{
    /// <summary>
    /// in this class is to read the Register  and login methods.
    /// </summary>
    public class Authentication
    {

        /// <summary>
        /// register method is to read user details.
        /// </summary>
        public void Register()
        {
            User userObj = new User();
            BALFactory balFactoryObj = new BALFactory();

            IValidation validationObj = balFactoryObj.GetBALValidationObj();
            IBAL balObj = balFactoryObj.GetBALAuthenticationObj();

            bool isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userName);
                userObj.userName = InputOutput.ReadInput();
                isvalid = validationObj.IsValidUserName(userObj.userName);
            }

            isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userPassword);
                userObj.userPassword = InputOutput.ReadInput();
                isvalid = validationObj.IsValidPassword(userObj.userPassword);
            }

            isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userMobilenumber);
                userObj.userMobilenumber = InputOutput.ReadInput();
                isvalid = validationObj.IsVaidMobileNumber(userObj.userMobilenumber);
            }

            isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userEmail);
                userObj.userEmail = InputOutput.ReadInput();
                isvalid = validationObj.IsValidUserEmail(userObj.userEmail);
            }

            //here it is going to check the isvalidregister is false and isregistered is also false then it is valid data and data will be stored, are if they are false then it is already exist in storeddata.
            if (!validationObj.IsRegistered(userObj))
            {
                balObj.Register(userObj);
                InputOutput.Display(Literals.registerCompleted);
            }
            else
            {
                InputOutput.Display(Literals.alreadyExist);
            }
        }

        /// <summary>
        /// This method will take input as userName and password ,if they are in registerData then it will login other wise invalid login details.
        /// </summary>
        public void Login()
        {
            User userObj = new User();
            BALFactory balFactoryObj = new BALFactory();
            IBAL balObj = balFactoryObj.GetBALAuthenticationObj();
            IValidation validationObj = balFactoryObj.GetBALValidationObj();

            InputOutput.Display(Literals.userName);
            userObj.userName = InputOutput.ReadInput();
            InputOutput.Display(Literals.userPassword);
            userObj.userPassword = InputOutput.ReadInput();

            bool isValid = balObj.Login(userObj);
            if (isValid)
            {
                InputOutput.Display(Literals.logined);
                InputOutput.Display(Literals.exitOptions);
                string input = InputOutput.ReadInput();
                if (input == "3")
                {
                    InputOutput.Display(Literals.logOut);
                }
                else if (input == "4")
                {
                    InputOutput.Display(Literals.userName);
                    userObj.userName = InputOutput.ReadInput();
                    InputOutput.Display(Literals.userPassword);
                    string newPassword = InputOutput.ReadInput();
                    if (validationObj.ToChangePassword(userObj, newPassword) == true)
                    {
                        InputOutput.Display(Literals.changePassword);
                    }
                }
            }
            else
            {
                InputOutput.Display("invalid login");
            }
        }
        public void GetData()
        {
            User userObj = new User();
            BALFactory balFactoryObj = new BALFactory();
            IBAL balObj = balFactoryObj.GetBALAuthenticationObj();

            string username = InputOutput.ReadInput();
            User obj = balObj.GetData(username);
            if (obj != null)
            {
                InputOutput.Display(obj.userMobilenumber);
                InputOutput.Display(obj.userEmail);
            }
            else
            {
                InputOutput.Display(Literals.notValidUserName);
            }
        }
    }
}
