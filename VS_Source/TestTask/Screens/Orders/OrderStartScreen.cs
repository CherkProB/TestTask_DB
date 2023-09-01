using TestTask.Screens.Base;
using TestTask.Screens.Start;

namespace TestTask.Screens.Orders
{
    public sealed class OrderStartScreen : BaseScreen
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
                    case "0": screenManager.SwitchScreen<StartScreen>(); return;
                    case "1": ShowAllOrders(); break;
                    case "2": ShowCustomerOrders(); break;
                    case "3": screenManager.SwitchScreen<OrderAddScreen>(); break;
                    case "4": screenManager.SwitchScreen<OrderDeleteScreen>(); break;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }
        }

        private void ShowAllOrders()
        {
            BaseObjects.Orders[] orders = screenManager.DBProvider.SelectAllOrders();

            foreach (BaseObjects.Orders order in orders)
                Console.WriteLine(order.ToString());
        }

        private void ShowCustomerOrders()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Список клиентов");
            Console.WriteLine("---------------");

            int customerId = BaseAddDeleteScreen.GetExistCustomerId("Введите ID клиента - ", screenManager.DBProvider);

            BaseObjects.Orders[] orders = screenManager.DBProvider.SelectAllOrdersByCustomerId(customerId);

            foreach (BaseObjects.Orders order in orders)
                Console.WriteLine(order.ToString());
        }
        #endregion
    }
}
