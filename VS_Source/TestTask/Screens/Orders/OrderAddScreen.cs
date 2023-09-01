using TestTask.Screens.Base;

namespace TestTask.Screens.Orders
{
    public sealed class OrderAddScreen : BaseAddDeleteScreen
    {
        #region Methods
        public override void Show()
        {
            BaseObjects.Orders newOrder = new BaseObjects.Orders();
            string? userInput = string.Empty;

            Console.WriteLine("---------------");
            Console.WriteLine("Добавление заказа");
            Console.WriteLine("---------------");

            newOrder.Title = GetSimpleText("Введите название нового товара - ");
            newOrder.Price = GetNumberText("Введите стоимость нового товара - ");
            newOrder.OrderDate = "Now";

            Console.WriteLine("---------------");
            Console.WriteLine("Список клиентов");
            Console.WriteLine("---------------");

            newOrder.CustomerId = GetExistCustomerId("Введите ID клиента - ");

            Console.WriteLine("---------------");
            Console.WriteLine("Созданный товар");
            Console.WriteLine("---------------");
            Console.WriteLine(newOrder.ToString());
            Console.WriteLine("---------------");
            Console.WriteLine("Вы действительно хотите добавить данный товар?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");
            Console.Write("Ваш выбор - ");

            userInput = Console.ReadLine();

            if (userInput == null) return;

            if (userInput == "1") screenManager.DBProvider.AddNewOrder(newOrder);
        }

        private int GetExistCustomerId(string outputText) => GetExistCustomerId(outputText, screenManager.DBProvider);
        #endregion
    }
}
