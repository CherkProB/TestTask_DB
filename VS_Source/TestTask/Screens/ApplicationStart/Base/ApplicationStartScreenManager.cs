using TestTask.Screens.ApplicationStart.Start;
using TestTask.Screens.Base;
using TestTask.Startup;

namespace TestTask.Screens.ApplicationStart.Base
{
    public sealed class ApplicationStartScreenManager : BaseScreenManager
    {
        #region FieldsAndProperties
        public DBSettings Settings { get => settings; set => settings = value; }
        private DBSettings settings;

        public string FileName { get => fileName; set => fileName = value; }
        private string fileName;
        #endregion

        #region Constructor
        public ApplicationStartScreenManager(ApplicationStartBaseScreen[] screens, string fileName, bool showStartScreen = true) : base(screens)
        {
            this.fileName = fileName;
            settings = new DBSettings();

            this.screens = new Dictionary<Type, BaseScreen>();

            foreach (ApplicationStartBaseScreen screen in screens)
            {
                this.screens.Add(screen.GetType(), screen);
                screen.AppScreenManager = this;
            }

            if (showStartScreen) SwitchScreen<ApplicationStartStartScreen>();
        }
        #endregion
    }
}
