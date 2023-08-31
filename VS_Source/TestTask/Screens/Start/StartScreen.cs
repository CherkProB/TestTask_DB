using TestTask.Screens.Base;
using TestTask.Screens.Customers;
using TestTask.Screens.Orders;

namespace TestTask.Screens.Start
{
    public sealed class StartScreen : BaseScreen
    {
        public StartScreen(ScreenManager screenManager) : base(screenManager) { }

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
                    case "1": screenManager.SwitchScreen<CustomersStartScreen>(); return;
                    case "2": screenManager.SwitchScreen<OrderStartScreen>(); return;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }

            
        }
    }
}
