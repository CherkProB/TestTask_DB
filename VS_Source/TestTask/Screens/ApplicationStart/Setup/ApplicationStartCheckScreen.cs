using TestTask.Screens.ApplicationStart.Base;
using TestTask.Screens.Base;

namespace TestTask.Screens.ApplicationStart.Setup
{
    public sealed class ApplicationStartCheckScreen : ApplicationStartBaseScreen
    {
        #region Method
        public override void Show()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Проверка настроек подключения к базе данных");
            Console.WriteLine("---------------");
            Console.WriteLine("Строка подключения:");
            Console.WriteLine(appScreenManager.Settings.ToString());
            Console.WriteLine("Настройки подключения:");
            Console.WriteLine(appScreenManager.Settings.ShowSettings());
            Console.WriteLine("Вы хотите изменить настройки подключения к базе данных?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");

            string userInput = BaseInputs.GetSimpleText("Ваш выбор - ");

            if (userInput == "1") appScreenManager.SwitchScreen<ApplicationStartSetupScreen>();
        }
        #endregion
    }
}
