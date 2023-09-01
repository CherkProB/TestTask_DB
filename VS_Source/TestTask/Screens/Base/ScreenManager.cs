using TestTask.DataBaseProviders.Base;
using TestTask.Screens.Start;

namespace TestTask.Screens.Base
{
    public sealed class ScreenManager
    {
        #region FieldsAndProperties
        public BaseDBProvider DBProvider { get => dbProvider; }
        private readonly BaseDBProvider dbProvider;

        private Dictionary<Type, BaseScreen> screens;
        private BaseScreen currentScreen;
        #endregion

        #region Constructor
        public ScreenManager(BaseDBProvider dbProvider, BaseScreen[] screens)
        {
            this.dbProvider = dbProvider;

            this.screens = new Dictionary<Type, BaseScreen>();
            foreach (BaseScreen screen in screens)
            {
                this.screens.Add(screen.GetType(), screen);
                screen.ScreenManager = this;
            }

            SwitchScreen<StartScreen>();
            currentScreen = screens[0];
        }
        #endregion

        #region Methods
        public void SwitchScreen<TScreen>() where TScreen : BaseScreen
        {
            BaseScreen newScreen = GetScreenByType<TScreen>();

            currentScreen = newScreen;
            currentScreen.Show();
        }

        private BaseScreen GetScreenByType<TScreen>() where TScreen : BaseScreen => (TScreen)screens[typeof(TScreen)];
        #endregion
    }
}
