using TestTask.Screens.Base;
using TestTask.Screens.DB.Base;

namespace TestTask.Screens.DB.Orders
{
    public sealed class DBOrderDeleteScreen : DBBaseScreen
    {
        #region Methods
        public override void Show()
        {
            BaseObjects.Orders? order = GetOrderById();

            if (order == null) return;

            Console.WriteLine("---------------");
            Console.WriteLine("Выбранный заказ");
            Console.WriteLine("---------------");
            Console.WriteLine(order.ToString());
            Console.WriteLine("---------------");
            Console.WriteLine("Вы действительно хотите удалить данный заказ?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");

            string userInput = BaseInputs.GetSimpleText("Ваш выбор - ");

            if (userInput == "1") dbScreenManager.DBProvider.DeleteOrderById(order.Id);
        }

        private BaseObjects.Orders? GetOrderById()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Список заказов");
            Console.WriteLine("---------------");

            int orderId = DBInputs.GetExistOrderId("Введите ID заказа - ", dbScreenManager.DBProvider);

            BaseObjects.Orders? order = dbScreenManager.DBProvider.SelectOrderById(orderId);

            return order;
        }
        #endregion
    }
}
