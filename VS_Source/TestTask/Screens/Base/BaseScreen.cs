namespace TestTask.Screens.Base
{
    public abstract class BaseScreen
    {
        #region FieldAndProperty
        public BaseScreenManager BaseScreenManager { set => baseScreenManager = value; }
        protected BaseScreenManager baseScreenManager;
        #endregion

        #region Method
        public abstract void Show();
        #endregion
    }
}
