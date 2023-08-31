using TestTask.DataBaseProviders.Base;
using TestTask.Screens.Customers;
using TestTask.Screens.Orders;
using TestTask.Screens.Start;

namespace TestTask.Screens.Base
{
    public class ScreenManager
    {
        public BaseDBProvider DBProvider { get; }
        private readonly BaseDBProvider dbProvider;

        private Dictionary<Type, BaseScreen> screens;
        private BaseScreen currentScreen;
        
        public ScreenManager(BaseDBProvider dbProvider) 
        {
            this.dbProvider = dbProvider;

            screens = new Dictionary<Type, BaseScreen>();

            screens.Add(typeof(StartScreen), new StartScreen(this));
            screens.Add(typeof(OrderStartScreen), new OrderStartScreen(this));
            screens.Add(typeof(CustomersStartScreen), new CustomersStartScreen(this));
            
            SwitchScreen<StartScreen>();
        }

        public void SwitchScreen<TScreen>() where TScreen : BaseScreen 
        {
            BaseScreen newScreen = GetScreenByType<TScreen>();

            currentScreen = newScreen;
            currentScreen.Show();
        }

        private BaseScreen GetScreenByType<TScreen>() where TScreen : BaseScreen => (TScreen)screens[typeof(TScreen)];
    }
}
