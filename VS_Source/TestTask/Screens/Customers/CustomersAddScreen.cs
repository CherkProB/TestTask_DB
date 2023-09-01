using TestTask.Screens.Base;

namespace TestTask.Screens.Customers
{
    public sealed class CustomersAddScreen : BaseScreen
    {
        public CustomersAddScreen(ScreenManager screenManager) : base(screenManager) { }

        public override void Show()
        {
            BaseObjects.Customers newCustomer = new BaseObjects.Customers();
            string? userInput = string.Empty;

            Console.WriteLine("---------------");
            Console.WriteLine("Добавление клиента");
            Console.WriteLine("---------------");

            newCustomer.Surname = GetSimpleText("Введите фамилию нового клиента - ");
            newCustomer.Name = GetSimpleText("Введите имя нового клиента - ");
            newCustomer.Email = GetEmailText("Введите email нового клиента - ");
            newCustomer.PhoneNumber = GetPhoneNumberText("Введите номер телефона нового клиента - ");

            Console.WriteLine("---------------");
            Console.WriteLine("Созданный клиент");
            Console.WriteLine("---------------");
            Console.WriteLine(newCustomer.ToString());
            Console.WriteLine("---------------");
            Console.WriteLine("Вы действительно хотите добавить данного пользователя?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");
            Console.Write("Ваш выбор - ");

            userInput = Console.ReadLine();

            if (userInput == null) return;

            if (userInput == "1") screenManager.DBProvider.AddNewCustomer(newCustomer);
        }

        private string GetSimpleText(string outputText)
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

        private string GetEmailText(string outputText)
        {
            string? userInput = string.Empty;

            while (true)
            {
                Console.Write(outputText);
                userInput = Console.ReadLine();

                if (userInput == null) continue;

                int aSymbol = userInput.LastIndexOf('@');
                int dotSymbol = userInput.LastIndexOf('.');

                if (dotSymbol > aSymbol && dotSymbol != -1 && aSymbol != -1)
                    return userInput;
                else
                    Console.WriteLine(@"Формат email: '[Любой набор символов]@[Любой набор символов].[Любой набор символов]'");
            }
        }

        private double GetPhoneNumberText(string outputText) 
        {
            string? userInput = string.Empty;

            while (true)
            {
                Console.Write(outputText);
                userInput = Console.ReadLine();

                if (userInput == null) continue;

                double phoneNumber;
                if (!double.TryParse(userInput, out phoneNumber))
                {
                    Console.WriteLine("Номер является набором цифр, который начинается с 8 и имеет длину 11");
                    continue;
                }

                if (phoneNumber < 80000000000 || phoneNumber >= 90000000000)
                {
                    Console.WriteLine("Номер является набором цифр, который начинается с 8 и имеет длину 11");
                    continue;
                }

                return phoneNumber;
            }
        }
    }
}
