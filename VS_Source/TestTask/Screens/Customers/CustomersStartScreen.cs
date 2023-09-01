using TestTask.Screens.Base;
using TestTask.Screens.Start;

namespace TestTask.Screens.Customers
{
    public sealed class CustomersStartScreen : BaseScreen
    {
        #region Methods
        public override void Show()
        {
            string? userInput = string.Empty;

            while (userInput != "0")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Клиенты");
                Console.WriteLine("---------------");
                Console.WriteLine("1 - Просмотреть все");
                Console.WriteLine("2 - Добавить нового клиента");
                Console.WriteLine("3 - Удалить клиента");
                Console.WriteLine("0 - Назад");
                Console.Write("Ваш выбор - ");

                userInput = Console.ReadLine();

                if (userInput == null) continue;

                switch (userInput)
                {
                    case "0": screenManager.SwitchScreen<StartScreen>(); return;
                    case "1": ShowAllCustomers(); break;
                    case "2": screenManager.SwitchScreen<CustomersAddScreen>(); break;
                    case "3": screenManager.SwitchScreen<CustomersDeleteScreen>(); break;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }
        }

        private void ShowAllCustomers()
        {
            BaseObjects.Customers[] customers = screenManager.DBProvider.SelectAllCustomers();

            foreach (BaseObjects.Customers customer in customers)
                Console.WriteLine(customer.ToString());
        }
        #endregion
    }
}
