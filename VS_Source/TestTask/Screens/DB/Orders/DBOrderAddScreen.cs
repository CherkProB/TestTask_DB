using TestTask.Screens.Base;
using TestTask.Screens.DB.Base;

namespace TestTask.Screens.DB.Orders
{
    public sealed class DBOrderAddScreen : DBBaseScreen
    {
        #region Methods
        public override void Show()
        {
            BaseObjects.Orders newOrder = new BaseObjects.Orders();

            Console.WriteLine("---------------");
            Console.WriteLine("Добавление заказа");
            Console.WriteLine("---------------");

            newOrder.Title = BaseInputs.GetSimpleText("Введите название нового товара - ");
            newOrder.Price = BaseInputs.GetNumberText("Введите стоимость нового товара - ");
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

            string userInput = BaseInputs.GetSimpleText("Ваш выбор - ");

            if (userInput == "1") dbScreenManager.DBProvider.AddNewOrder(newOrder);
        }

        private int GetExistCustomerId(string outputText) => DBInputs.GetExistCustomerId(outputText, dbScreenManager.DBProvider);
        #endregion
    }
}
