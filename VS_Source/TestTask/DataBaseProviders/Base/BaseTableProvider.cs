namespace TestTask.DataBaseProviders.Base
{
    public abstract class BaseTableProvider
    {
        #region Declaration
        public bool IsDetailed { get => isDetailed; set => isDetailed = value; }
        protected bool isDetailed;

        protected string? connectionString;
        protected string? tableName;
        #endregion Region
    }
}
