using MySql.Data.MySqlClient;
using System.Data;
using System.Text;
using TestTask.BaseObjects;
using TestTask.DataBaseProviders.Base;

namespace TestTask.DataBaseProviders.MySQL
{
    public abstract class MySQLTableProvider : BaseTableProvider
    {
        #region Constructor
        public MySQLTableProvider(string connectionString, string tableName)
        {
            isDetailed = true;

            this.connectionString = connectionString;
            this.tableName = tableName;
        }
        #endregion

        #region Requests
        public DataSet Select(string request) 
        {
            DataSet newDataSet = new DataSet();
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                if (isDetailed) Console.WriteLine("Установка соединения с базой данных...");

                connection.Open();

                if (isDetailed) Console.WriteLine("Соединение с базой данных установлено.");
                if (isDetailed) Console.WriteLine("Получение данных из таблицы...");

                MySqlDataAdapter adapter = new MySqlDataAdapter(request, connection);
                adapter.Fill(newDataSet);

                if (isDetailed) Console.WriteLine("Данные успешно получены.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("При попытки получить данные произошла ошибка!\n" + ex.Message);
            }

            connection.Close();

            return newDataSet;
        }

        public DataSet SelectAll() => Select("SELECT * FROM " + tableName);

        public void InsertQuery(string request) 
        {
            MySqlConnection connection = new MySqlConnection(connectionString);

            try 
            {
                if (isDetailed) Console.WriteLine("Установка соединения с базой данных...");

                connection.Open();

                if (isDetailed) Console.WriteLine("Соединение с базой данных установлено.");
                if (isDetailed) Console.WriteLine("Выполнение запроса ...");

                MySqlCommand command = new MySqlCommand(request, connection);
                command.ExecuteNonQuery();

                if (isDetailed) Console.WriteLine("Запрос успешно выполнен.");

            }
            catch (Exception ex) 
            {
                Console.WriteLine("При выполнить запрос произошла ошибка!\n" + ex.Message);
            }

            connection.Close();
        }
        #endregion
    }
}
