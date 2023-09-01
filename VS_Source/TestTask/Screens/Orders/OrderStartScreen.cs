using TestTask.Screens.Base;
using TestTask.Screens.Start;

namespace TestTask.Screens.Orders
{
    public sealed class OrderStartScreen : BaseScreen
    {
        public OrderStartScreen(ScreenManager screenManager) : base(screenManager) { }

        public override void Show()
        {
            string? userInput = string.Empty;

            while (userInput != "0")
            {
                Console.WriteLine("---------------");
                Console.WriteLine("Заказы");
                Console.WriteLine("---------------");
                Console.WriteLine("1 - Просмотреть");
                Console.WriteLine("2 - Добавить");
                Console.WriteLine("3 - Удалить");
                Console.WriteLine("0 - Назад");
                Console.Write("Ваш выбор - ");

                userInput = Console.ReadLine();

                if (userInput == null) continue;

                switch (userInput)
                {
                    case "0": screenManager.SwitchScreen<StartScreen>(); return;
                    //case "1": screenManager.SwitchScreen<StartScreen>(); return;
                    //case "2": screenManager.SwitchScreen<StartScreen>(); return;
                    //case "3": screenManager.SwitchScreen<StartScreen>(); return;
                    default: Console.WriteLine("Введен неверный номер!"); break;
                }
            }
        }
    }
}
