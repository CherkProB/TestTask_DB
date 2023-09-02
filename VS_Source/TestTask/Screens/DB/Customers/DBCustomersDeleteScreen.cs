using TestTask.Screens.Base;
using TestTask.Screens.DB.Base;

namespace TestTask.Screens.DB.Customers
{
    public sealed class DBCustomersDeleteScreen : DBBaseScreen
    {
        #region Methods
        public override void Show()
        {
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

            string userInput = BaseInputs.GetSimpleText("Ваш выбор - ");

            if (userInput == "1") dbScreenManager.DBProvider.DeleteCustomerById(customer.Id);
        }

        private BaseObjects.Customers? GetCustomerById()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Список клиентов");
            Console.WriteLine("---------------");

            int customerId = DBInputs.GetExistCustomerId("Введите ID клиента - ", dbScreenManager.DBProvider);

            BaseObjects.Customers? customers = dbScreenManager.DBProvider.SelectCustomerById(customerId);

            return customers;
        }
        #endregion
    }
}
