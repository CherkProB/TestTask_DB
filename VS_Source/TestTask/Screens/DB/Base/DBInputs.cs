using TestTask.Screens.Base;

namespace TestTask.Screens.DB.Base
{
    public static class DBInputs
    {
        #region Methods
        public static string GetEmailText(string outputText)
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

        public static double GetPhoneNumberText(string outputText)
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
                int customerId = BaseInputs.GetNumberText(outputText);

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
                int orderId = BaseInputs.GetNumberText(outputText);

                if (existingIds.Contains(orderId))
                    return orderId;

                Console.WriteLine("Не существует заказ с выбранным ID!");
            }
        }
        #endregion
    }
}