using TestTask.Screens.DB.Base;
using TestTask.Screens.DB.Start;

namespace TestTask.Screens.DB.Customers
{
    public sealed class DBCustomersStartScreen : DBBaseScreen
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
                    case "0": baseScreenManager.SwitchScreen<DBStartScreen>(); return;
                    case "1": ShowAllCustomers(); break;
                    case "2": baseScreenManager.SwitchScreen<DBCustomersAddScreen>(); break;
                    case "3": baseScreenManager.SwitchScreen<DBCustomersDeleteScreen>(); break;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }
        }

        private void ShowAllCustomers()
        {
            BaseObjects.Customers[] customers = dbScreenManager.DBProvider.SelectAllCustomers();

            foreach (BaseObjects.Customers customer in customers)
                Console.WriteLine(customer.ToString());
        }
        #endregion
    }
}
