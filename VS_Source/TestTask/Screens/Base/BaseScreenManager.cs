namespace TestTask.Screens.Base
{
    public abstract class BaseScreenManager
    {
        #region Fields
        protected Dictionary<Type, BaseScreen> screens;
        private BaseScreen? currentScreen;
        #endregion

        #region Constructor
        public BaseScreenManager(BaseScreen[] screens)
        {
            this.screens = new Dictionary<Type, BaseScreen>();
            foreach (BaseScreen screen in screens)
            {
                this.screens.Add(screen.GetType(), screen);
                screen.BaseScreenManager = this;
            }
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
