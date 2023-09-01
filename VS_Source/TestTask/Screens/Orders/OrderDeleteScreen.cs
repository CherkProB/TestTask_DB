using TestTask.Screens.Base;

namespace TestTask.Screens.Orders
{
    public sealed class OrderDeleteScreen : BaseAddDeleteScreen
    {
        #region Methods
        public override void Show()
        {
            string? userInput = string.Empty;

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
            Console.Write("Ваш выбор - ");

            userInput = Console.ReadLine();

            if (userInput == null) return;

            if (userInput == "1") screenManager.DBProvider.DeleteOrderById(order.Id);
        }

        private BaseObjects.Orders? GetOrderById()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Список заказов");
            Console.WriteLine("---------------");

            int orderId = GetExistOrderId("Введите ID заказа - ", screenManager.DBProvider);

            BaseObjects.Orders? order = screenManager.DBProvider.SelectOrderById(orderId);

            return order;
        }
        #endregion
    }
}
