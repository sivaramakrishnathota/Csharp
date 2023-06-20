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
            Exit = 0
        }

        public static void Main(string[] args)
        {
            Authentication AuthenticationObj = new Authentication();
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

                            AuthenticationObj.Register();
                            break;
                        case Input.Login:
                            AuthenticationObj.Login();
                            break;
                        case Input.Exit:
                            check = false;
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
