using TestTask.DataBaseProviders.Base;
using TestTask.Screens.Base;
using TestTask.Screens.DB.Start;

namespace TestTask.Screens.DB.Base
{
    public sealed class DBScreenManager : BaseScreenManager
    {
        #region FieldAndProperty
        public BaseDBProvider DBProvider { get => dbProvider; }
        private readonly BaseDBProvider dbProvider;
        #endregion

        #region Constructor
        public DBScreenManager(DBBaseScreen[] screens, BaseDBProvider dbProvider, bool showStartScreen = true) : base(screens)
        {
            this.dbProvider = dbProvider;

            this.screens = new Dictionary<Type, BaseScreen>();
            foreach (DBBaseScreen screen in screens)
            {
                this.screens.Add(screen.GetType(), screen);
                screen.DBScreenManager = this;
            }

            if (showStartScreen) SwitchScreen<DBStartScreen>();
        }
        #endregion
    }
}