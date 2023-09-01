using TestTask.Screens.Base;

namespace TestTask.Screens.Customers
{
    public sealed class CustomersDeleteScreen : BaseScreen
    {
        public CustomersDeleteScreen(ScreenManager screenManager) : base(screenManager) { }

        public override void Show()
        {
            string? userInput = string.Empty;

            BaseObjects.Customers? customer = GetCustomerById();

            if (customer == null) return;

            Console.WriteLine("---------------");
            Console.WriteLine("Выбранный клиент");
            Console.WriteLine("---------------");
            Console.WriteLine(customer.ToString());
            Console.WriteLine("---------------");
            Console.WriteLine("Вы действительно хотите удалить данного пользователя?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");
            Console.Write("Ваш выбор - ");

            userInput = Console.ReadLine();

            if (userInput == null) return;

            if (userInput == "1") screenManager.DBProvider.DeleteCustomersById(customer.Id);
        }

        private BaseObjects.Customers? GetCustomerById() 
        {
            string? userInput = string.Empty;

            int customerId;

            while (true)
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Удаление клиента");
                Console.WriteLine("---------------");
                Console.Write("Введите Id клиента, которого хотите удалить (-1 для выхода) - ");

                userInput = Console.ReadLine();

                if (userInput == null) return null;
                if (userInput == "-1") return null;

                if (!int.TryParse(userInput, out customerId))
                { Console.WriteLine("Был введен некорректный Id!"); continue; }
                else
                    break;
            }

            BaseObjects.Customers? customers = screenManager.DBProvider.SelectCustomerById(customerId);

            if (customers == null) Console.WriteLine("Клиент с введеным Id не существует!");
            return customers;
        }
    }
}
