using TestTask.Screens.Base;

namespace TestTask.Screens.DB.Base
{
    public abstract class DBBaseScreen : BaseScreen
    {
        #region FieldAndProperty
        public DBScreenManager DBScreenManager { set => dbScreenManager = value; }
        protected DBScreenManager dbScreenManager;
        #endregion
    }
}