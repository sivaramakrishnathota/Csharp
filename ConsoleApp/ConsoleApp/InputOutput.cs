namespace ConsoleApp
{
    /// <summary>
    /// in this class has the readinput and display methods.
    /// </summary>
    public static class InputOutput
    {
        public static string ReadInput()
        {
            return Console.ReadLine();
        }
        public static void Display(string input)
        {
            Console.WriteLine(input);
        }
    }
}
