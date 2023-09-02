using TestTask.Screens.Base;
using TestTask.Screens.DB.Base;

namespace TestTask.Screens.DB.Customers
{
    public sealed class DBCustomersAddScreen : DBBaseScreen
    {
        #region Method
        public override void Show()
        {
            BaseObjects.Customers newCustomer = new BaseObjects.Customers();

            Console.WriteLine("---------------");
            Console.WriteLine("Добавление клиента");
            Console.WriteLine("---------------");

            newCustomer.Surname = BaseInputs.GetSimpleText("Введите фамилию нового клиента - ");
            newCustomer.Name = BaseInputs.GetSimpleText("Введите имя нового клиента - ");
            newCustomer.Email = DBInputs.GetEmailText("Введите email нового клиента - ");
            newCustomer.PhoneNumber = DBInputs.GetPhoneNumberText("Введите номер телефона нового клиента - ");

            Console.WriteLine("---------------");
            Console.WriteLine("Созданный клиент");
            Console.WriteLine("---------------");
            Console.WriteLine(newCustomer.ToString());
            Console.WriteLine("---------------");
            Console.WriteLine("Вы действительно хотите добавить данного пользователя?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");

            string userInput = BaseInputs.GetSimpleText("Ваш выбор - ");

            if (userInput == "1") dbScreenManager.DBProvider.AddNewCustomer(newCustomer);
        }
        #endregion
    }
}
