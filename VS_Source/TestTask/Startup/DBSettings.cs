using System.Text;

namespace TestTask.Startup
{
    /// <summary>
    /// Connection settings class
    /// </summary>
    public sealed class DBSettings
    {
        #region FieldsAndProperties
        /// <summary>
        /// Database Server 
        /// </summary>
        public string Server { get => server; set => server = value; }
        private string server;
        /// <summary>
        /// Database Port
        /// </summary>
        public string Port { get => port; set => port = value; }
        private string port;
        /// <summary>
        /// Database Username
        /// </summary>
        public string Username { get => username; set => username = value; }
        private string username;
        /// <summary>
        /// Database Password
        /// </summary>
        public string Password { get => password; set => password = value; }
        private string password;
        /// <summary>
        /// Database Name
        /// </summary>
        public string Database { get => database; set => database = value; }
        private string database;
        /// <summary>
        /// Database logs
        /// </summary>
        public bool IsDetailed { get => isDetailed; set => isDetailed = value; }
        private bool isDetailed;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor without parameters
        /// Creating empty class
        /// </summary>
        public DBSettings()
        {
            server = port = username = password = database = string.Empty;
            isDetailed = false;
        }
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendFormat("server={0};port={1};username={2};password={3};database={4}", server, port, username, password, database);

            return stringBuilder.ToString();
        }
        #endregion

        #region Method
        /// <summary>
        /// Returns a string that represents that current object in format
        /// </summary>
        /// <returns>Returns object in string format</returns>
        public string ShowSettings()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("Server: ");
            stringBuilder.AppendLine(server);
            stringBuilder.Append("Port: ");
            stringBuilder.AppendLine(port);
            stringBuilder.Append("Username: ");
            stringBuilder.AppendLine(username);
            stringBuilder.Append("Password: ");
            stringBuilder.AppendLine(password);
            stringBuilder.Append("Database: ");
            stringBuilder.Append(database);

            return stringBuilder.ToString();
        }
        #endregion
    }
}
