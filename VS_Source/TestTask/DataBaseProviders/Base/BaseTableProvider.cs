namespace TestTask.DataBaseProviders.Base
{
    public abstract class BaseTableProvider
    {
        #region FieldsAndProperties
        public bool IsDetailed { get => isDetailed; set => isDetailed = value; }
        protected bool isDetailed;

        protected string tableName;
        #endregion Region

        #region Constructor
        public BaseTableProvider(string tableName)
        {
            this.tableName = tableName;
        }
        #endregion Region
    }
}
