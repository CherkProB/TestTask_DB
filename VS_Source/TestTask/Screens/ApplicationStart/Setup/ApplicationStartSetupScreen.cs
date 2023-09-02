using Newtonsoft.Json;
using TestTask.Screens.ApplicationStart.Base;
using TestTask.Screens.Base;
using TestTask.Startup;

namespace TestTask.Screens.ApplicationStart.Setup
{
    public sealed class ApplicationStartSetupScreen : ApplicationStartBaseScreen
    {
        #region Methods
        public override void Show()
        {
            Console.WriteLine("---------------");
            Console.WriteLine("Настройка подключения к базе данных");
            Console.WriteLine("---------------");

            var dbSettings = new DBSettings();

            dbSettings.Server = BaseInputs.GetSimpleText("Server - ");
            dbSettings.Port = BaseInputs.GetSimpleText("Port - ");
            dbSettings.Username = BaseInputs.GetSimpleText("Username - ");
            dbSettings.Password = BaseInputs.GetSimpleText("Password - ");
            dbSettings.Database = BaseInputs.GetSimpleText("Database - ");
            dbSettings.IsDetailed = BaseInputs.GetBoolText("Подробное описание доступа к данным? - ");

            appScreenManager.Settings = dbSettings;

            CreateJsonFromDBSettinngs(dbSettings);
        }

        private string CreateJsonFromDBSettinngs(DBSettings dbSettings) 
        {
            string json = JsonConvert.SerializeObject(dbSettings);

            StreamWriter sw = new StreamWriter(appScreenManager.FileName);
            sw.WriteLine(json);
            sw.Close();

            return json;
        }
        #endregion
    }
}
