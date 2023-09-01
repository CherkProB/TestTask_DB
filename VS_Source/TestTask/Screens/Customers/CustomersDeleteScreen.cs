using TestTask.Screens.Base;

namespace TestTask.Screens.Customers
{
    public sealed class CustomersDeleteScreen : BaseAddDeleteScreen
    {
        #region Methods
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

            if (userInput == "1") screenManager.DBProvider.DeleteCustomerById(customer.Id);
        }

        private BaseObjects.Customers? GetCustomerById()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Список клиентов");
            Console.WriteLine("---------------");

            int customerId = GetExistCustomerId("Введите ID клиента - ", screenManager.DBProvider);

            BaseObjects.Customers? customers = screenManager.DBProvider.SelectCustomerById(customerId);

            return customers;
        }
        #endregion
    }
}
