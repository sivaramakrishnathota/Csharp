using BusinessLayer;
using BusinessModel;

namespace ConsoleApp
{
    /// <summary>
    /// in this class is to read the Register  and login methods.
    /// </summary>
    public class Authentication
    {
        BALFactory businessLogicFactory = new BALFactory();
        /// <summary>
        /// register method is to read user details.
        /// </summary>
        public void Register()
        {
            User UserObj = new User();
            BALFactory BALFactoryObj = new BALFactory();

            IValidation ValidationObj = BALFactoryObj.GetBALValidationObj();
            IBAL BALObj = BALFactoryObj.GetBALAuthenticationObj();

            bool isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userName);
                UserObj.userName = InputOutput.ReadInput();
                isvalid = ValidationObj.IsValidUserName(UserObj.userName);
            }

            isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userPassword);
                UserObj.userPassword = InputOutput.ReadInput();
                isvalid = ValidationObj.IsValidPassword(UserObj.userPassword);
            }

            isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userMobilenumber);
                UserObj.userMobilenumber = InputOutput.ReadInput();
                isvalid = ValidationObj.IsVaidMobileNumber(UserObj.userMobilenumber);
            }

            isvalid = false;
            while (!isvalid)
            {
                InputOutput.Display(Literals.userEmail);
                UserObj.userEmail = InputOutput.ReadInput();
                isvalid = ValidationObj.IsValidUserEmail(UserObj.userEmail);
            }

            if (!ValidationObj.IsRegistered(UserObj))
            {
                BALObj.Register(UserObj);
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
            User UserObj = new User();

            InputOutput.Display(Literals.userName);
            UserObj.userName = InputOutput.ReadInput();
            InputOutput.Display(Literals.userPassword);
            UserObj.userPassword = InputOutput.ReadInput();

            BALFactory BALFactoryObj = new BALFactory();
            IBAL BALObj = BALFactoryObj.GetBALAuthenticationObj();
            IValidation ValidationObj = BALFactoryObj.GetBALValidationObj();
            bool isValid = BALObj.Login(UserObj);
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
                    UserObj.userName = InputOutput.ReadInput();
                    InputOutput.Display(Literals.userPassword);
                    string newPassword = InputOutput.ReadInput();
                    if (ValidationObj.ToChangePassword(UserObj, newPassword) == true)
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
    }
}
