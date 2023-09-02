using TestTask.DataBaseProviders.Base;
using TestTask.DataBaseProviders.MySQL;
using TestTask.Screens.ApplicationStart.Base;
using TestTask.Screens.ApplicationStart.Setup;
using TestTask.Screens.ApplicationStart.Start;
using TestTask.Screens.DB.Base;
using TestTask.Screens.DB.Customers;
using TestTask.Screens.DB.Orders;
using TestTask.Screens.DB.Start;

namespace TestTask.Startup
{
    public class Program
    {
        #region Constant
        /// <summary>
        /// Constant name of the file where the settings are saved
        /// </summary>
        private const string jsonFileName = "DBSettings.json";
        #endregion

        #region EntryPoint
        /// <summary>
        /// Application entry point 
        /// </summary>
        /// <param name="args">Parametrs</param>
        private static void Main(string[] args)
        {
            ApplicationStartBaseScreen[] appStartScreens = GetApplicationStartBaseScreens();

            ApplicationStartScreenManager appStartScreenManager = new ApplicationStartScreenManager(appStartScreens, jsonFileName);

            string connectionString = appStartScreenManager.Settings.ToString();
            bool isDetailed = appStartScreenManager.Settings.IsDetailed;

            BaseDBProvider baseDBProvider = new MySQLDBProvider(connectionString, isDetailed);

            if (!baseDBProvider.CheckConnection()) return;

            DBBaseScreen[] dbScreens = GetDBScreens();

            DBScreenManager screenManager = new DBScreenManager(dbScreens, baseDBProvider);
        }
        #endregion

        #region ScreensSetup
        /// <summary>
        /// Method that returns all existing screens for db screen manager
        /// </summary>
        /// <returns>Returns all existiong screens</returns>
        private static DBBaseScreen[] GetDBScreens()
        {
            List<DBBaseScreen> screens = new List<DBBaseScreen>();

            screens.Add(new DBStartScreen());

            screens.Add(new DBCustomersStartScreen());
            screens.Add(new DBCustomersAddScreen());
            screens.Add(new DBCustomersDeleteScreen());

            screens.Add(new DBOrderStartScreen());
            screens.Add(new DBOrderAddScreen());
            screens.Add(new DBOrderDeleteScreen());

            return screens.ToArray();
        }

        /// <summary>
        /// Method that returns all existing screens for application start screen manager
        /// </summary>
        /// <returns>Returns all existiong screens</returns>
        private static ApplicationStartBaseScreen[] GetApplicationStartBaseScreens()
        {
            List<ApplicationStartBaseScreen> screens = new List<ApplicationStartBaseScreen>();

            screens.Add(new ApplicationStartStartScreen());
            screens.Add(new ApplicationStartSetupScreen());
            screens.Add(new ApplicationStartCheckScreen());

            return screens.ToArray();
        }
        #endregion

    }
}