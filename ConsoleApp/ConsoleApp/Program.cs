using BusinessModel;

namespace ConsoleApp
{
    public class InternalApp
    {
        /// <summary>
        /// in this enum has the required inputs.
        /// </summary>
        public enum Input
        {
            Register = 1,
            Login = 2,
            GetData = 5,
            Exit = 0
        }

        public static void Main(string[] args)
        {
            Authentication authenticationObj = new Authentication();
            bool check = true;
            while (check)
            {
                InputOutput.Display(Literals.UserOption);

                string input1 = InputOutput.ReadInput();

                if (Enum.TryParse<Input>(input1, out var inputValue))
                {
                    switch (inputValue)
                    {
                        case Input.Register:

                            authenticationObj.Register();
                            break;
                        case Input.Login:
                            authenticationObj.Login();
                            break;
                        case Input.Exit:
                            check = false;
                            break;
                        case Input.GetData:
                            authenticationObj.GetData();
                            break;
                        default:
                            InputOutput.Display(Literals.UserOption);
                            break;
                    }
                }
            }
        }
    }
}
