namespace TestTask.Screens.Base
{
    public abstract class BaseScreen
    {
        #region FieldAndProperty
        public ScreenManager ScreenManager { set => screenManager = value; }
        protected ScreenManager screenManager;
        #endregion

        #region Method
        public abstract void Show();
        #endregion
    }
}