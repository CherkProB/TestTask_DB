using TestTask.Screens.Base;

namespace TestTask.Screens.Customers
{
    public sealed class CustomersAddScreen : BaseAddDeleteScreen
    {
        #region Method
        public override void Show()
        {
            BaseObjects.Customers newCustomer = new BaseObjects.Customers();
            string? userInput = string.Empty;

            Console.WriteLine("---------------");
            Console.WriteLine("Добавление клиента");
            Console.WriteLine("---------------");

            newCustomer.Surname = GetSimpleText("Введите фамилию нового клиента - ");
            newCustomer.Name = GetSimpleText("Введите имя нового клиента - ");
            newCustomer.Email = GetEmailText("Введите email нового клиента - ");
            newCustomer.PhoneNumber = GetPhoneNumberText("Введите номер телефона нового клиента - ");

            Console.WriteLine("---------------");
            Console.WriteLine("Созданный клиент");
            Console.WriteLine("---------------");
            Console.WriteLine(newCustomer.ToString());
            Console.WriteLine("---------------");
            Console.WriteLine("Вы действительно хотите добавить данного пользователя?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");
            Console.Write("Ваш выбор - ");

            userInput = Console.ReadLine();

            if (userInput == null) return;

            if (userInput == "1") screenManager.DBProvider.AddNewCustomer(newCustomer);
        }
        #endregion
    }
}
