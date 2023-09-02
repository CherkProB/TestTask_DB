using TestTask.Screens.DB.Base;
using TestTask.Screens.DB.Start;

namespace TestTask.Screens.DB.Orders
{
    public sealed class DBOrderStartScreen : DBBaseScreen
    {
        #region Methods
        public override void Show()
        {
            string? userInput = string.Empty;

            while (userInput != "0")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Заказы");
                Console.WriteLine("---------------");
                Console.WriteLine("1 - Просмотреть все");
                Console.WriteLine("2 - Просмотреть заказы определенного клиента");
                Console.WriteLine("3 - Добавить новый заказ");
                Console.WriteLine("4 - Удалить заказ");
                Console.WriteLine("0 - Назад");
                Console.Write("Ваш выбор - ");

                userInput = Console.ReadLine();

                if (userInput == null) continue;

                switch (userInput)
                {
                    case "0": baseScreenManager.SwitchScreen<DBStartScreen>(); return;
                    case "1": ShowAllOrders(); break;
                    case "2": ShowCustomerOrders(); break;
                    case "3": baseScreenManager.SwitchScreen<DBOrderAddScreen>(); break;
                    case "4": baseScreenManager.SwitchScreen<DBOrderDeleteScreen>(); break;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }
        }

        private void ShowAllOrders()
        {
            BaseObjects.Orders[] orders = dbScreenManager.DBProvider.SelectAllOrders();

            foreach (BaseObjects.Orders order in orders)
                Console.WriteLine(order.ToString());
        }

        private void ShowCustomerOrders()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Список клиентов");
            Console.WriteLine("---------------");

            int customerId = DBInputs.GetExistCustomerId("Введите ID клиента - ", dbScreenManager.DBProvider);

            BaseObjects.Orders[] orders = dbScreenManager.DBProvider.SelectAllOrdersByCustomerId(customerId);

            foreach (BaseObjects.Orders order in orders)
                Console.WriteLine(order.ToString());
        }
        #endregion
    }
}
