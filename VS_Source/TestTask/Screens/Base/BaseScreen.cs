using System;

namespace TestTask.Screens.Base
{
    public abstract class BaseScreen
    {
        protected ScreenManager screenManager;

        public BaseScreen(ScreenManager screenManager)
        {
            this.screenManager = screenManager;
        }


        public abstract void Show();
    }
}
