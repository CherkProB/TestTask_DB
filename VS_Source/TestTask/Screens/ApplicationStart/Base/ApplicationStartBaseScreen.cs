using TestTask.Screens.Base;

namespace TestTask.Screens.ApplicationStart.Base
{
    public abstract class ApplicationStartBaseScreen : BaseScreen
    {
        #region FieldAndProperty
        public ApplicationStartScreenManager AppScreenManager { set => appScreenManager = value; }
        protected ApplicationStartScreenManager appScreenManager;
        #endregion
    }
}
