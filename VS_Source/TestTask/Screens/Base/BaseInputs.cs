namespace TestTask.Screens.Base
{
    public static class BaseInputs
    {
        #region Methods
        public static string GetSimpleText(string outputText)
        {
            string? userInput = string.Empty;

            while (true)
            {
                Console.Write(outputText);
                userInput = Console.ReadLine();

                if (userInput == null)
                    continue;
                else
                    return userInput;
            }
        }

        public static int GetNumberText(string outputText)
        {
            string? userInput = string.Empty;

            while (true)
            {
                Console.Write(outputText);
                userInput = Console.ReadLine();

                if (userInput == null) continue;

                int number;
                if (!int.TryParse(userInput, out number))
                {
                    Console.WriteLine("Невозможно преобразовать число!");
                    continue;
                }
                else
                    return number;
            }
        }

        public static bool GetBoolText(string outputText) 
        {
            string? userInput = string.Empty;

            while (true)
            {
                Console.Write("[True/False] " + outputText);
                userInput = Console.ReadLine();

                if (userInput == null) continue;

                bool flag;
                if (!bool.TryParse(userInput, out flag))
                {
                    Console.WriteLine("Невозможно преобразовать логическую переменную!");
                    continue;
                }
                else
                    return flag;
            }
        } 
        #endregion
    }
}
