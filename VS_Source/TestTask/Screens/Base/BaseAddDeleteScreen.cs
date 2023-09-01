namespace TestTask.Screens.Base
{
    public abstract class BaseAddDeleteScreen : BaseScreen
    {
        #region Methods
        protected static string GetSimpleText(string outputText)
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

        protected static int GetNumberText(string outputText)
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

        protected static string GetEmailText(string outputText)
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

        protected static double GetPhoneNumberText(string outputText)
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

        public static int GetExistCustomerId(string outputText, DataBaseProviders.Base.BaseDBProvider baseDBProvider)
        {
            BaseObjects.Customers[] customers = baseDBProvider.SelectAllCustomers();
            List<int> existingIds = new List<int>();

            foreach (BaseObjects.Customers customer in customers)
            {
                Console.WriteLine(customer.ToString());
                existingIds.Add(customer.Id);
            }

            while (true)
            {
                int customerId = GetNumberText(outputText);

                if (existingIds.Contains(customerId))
                    return customerId;

                Console.WriteLine("Не существует клиента с выбранным ID!");
            }
        }

        public static int GetExistOrderId(string outputText, DataBaseProviders.Base.BaseDBProvider baseDBProvider)
        {
            BaseObjects.Orders[] orders = baseDBProvider.SelectAllOrders();
            List<int> existingIds = new List<int>();

            foreach (BaseObjects.Orders order in orders)
            {
                Console.WriteLine(order.ToString());
                existingIds.Add(order.Id);
            }

            while (true)
            {
                int orderId = GetNumberText(outputText);

                if (existingIds.Contains(orderId))
                    return orderId;

                Console.WriteLine("Не существует заказ с выбранным ID!");
            }
        }
        #endregion
    }
}
