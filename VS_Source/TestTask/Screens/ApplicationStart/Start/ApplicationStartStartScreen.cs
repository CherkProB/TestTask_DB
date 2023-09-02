using Newtonsoft.Json;
using TestTask.Screens.ApplicationStart.Base;
using TestTask.Screens.ApplicationStart.Setup;
using TestTask.Screens.Base;
using TestTask.Startup;

namespace TestTask.Screens.ApplicationStart.Start
{
    public class ApplicationStartStartScreen : ApplicationStartBaseScreen
    {
        #region Methods
        public override void Show()
        {
            Console.WriteLine("Запуск приложения...");

            if (!File.Exists(appScreenManager.FileName))
            {
                appScreenManager.SwitchScreen<ApplicationStartSetupScreen>();
                return;
            }

            DBSettings? dbSettings = GetDBSettingsFromJson();

            if (dbSettings == null)
            {
                Console.WriteLine("При получении объекта из json произошла ошибка!");
                return;
            }

            appScreenManager.Settings = dbSettings;

            Console.WriteLine("---------------");
            Console.WriteLine("Вы хотите проверить настройки подключения к базе данных?");
            Console.WriteLine("1 - Да");
            Console.WriteLine("Любая кнопка - Нет");
            string userInput = BaseInputs.GetSimpleText("Ваш выбор - ");

            if (userInput == "1") appScreenManager.SwitchScreen<ApplicationStartCheckScreen>();
        }

        private DBSettings? GetDBSettingsFromJson()
        {
            StreamReader sr = new StreamReader(appScreenManager.FileName);
            string json = sr.ReadToEnd();
            sr.Close();

            return JsonConvert.DeserializeObject<DBSettings>(json);
        }
        #endregion
    }
}
