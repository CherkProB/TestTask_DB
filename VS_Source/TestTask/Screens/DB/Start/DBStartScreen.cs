using TestTask.Screens.DB.Base;
using TestTask.Screens.DB.Customers;
using TestTask.Screens.DB.Orders;

namespace TestTask.Screens.DB.Start
{
    public sealed class DBStartScreen : DBBaseScreen
    {
        #region Method
        public override void Show()
        {
            string? userInput = string.Empty;

            while (userInput != "0")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Стартовый Экран");
                Console.WriteLine("---------------");
                Console.WriteLine("1 - Клиенты");
                Console.WriteLine("2 - Заказы");
                Console.WriteLine("0 - Выход");
                Console.Write("Ваш выбор - ");

                userInput = Console.ReadLine();

                if (userInput == null) continue;

                switch (userInput)
                {
                    case "0": Console.WriteLine("До Свидания!"); Environment.Exit(0); return;
                    case "1": baseScreenManager.SwitchScreen<DBCustomersStartScreen>(); return;
                    case "2": baseScreenManager.SwitchScreen<DBOrderStartScreen>(); return;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }
        }
        #endregion
    }
}
