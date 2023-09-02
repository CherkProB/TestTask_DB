using System.Data;
using System.Text;
using TestTask.BaseObjects;

namespace TestTask.DataBaseProviders.MySQL
{
    public sealed class MySQLCustomersTableProvider : MySQLTableProvider
    {
        #region RequestTemplates
        private const string SelectRequestTemplate = @"SELECT * FROM `customers` WHERE `id_customer` = {0}";
        private const string InsertRequestTemplate = @"INSERT INTO `customers`(`surname`, `name`, `email`, `phone_number`) VALUES ('{0}','{1}','{2}','{3}')";
        private const string DeleteRequestTemplate = @"DELETE FROM `customers` WHERE `id_customer` = {0}";
        #endregion

        #region Constructor
        public MySQLCustomersTableProvider(string connectionString, string tableName) :
            base(connectionString, tableName) { }
        #endregion

        #region Requests
        public Customers[] SelectAllCustomers()
        {
            List<Customers> customers = new List<Customers>();
            DataTable? customersTable = SelectAll();

            if (customersTable != null)
                foreach (DataRow row in customersTable.Rows)
                    customers.Add(new Customers(row));

            return customers.ToArray();
        }

        public Customers? SelectCustomerById(int customerId)
        {
            StringBuilder requstBuilder = new StringBuilder();
            requstBuilder.AppendFormat(SelectRequestTemplate, customerId);

            DataTable? customerTable = Select(requstBuilder.ToString());

            if (customerTable == null) return null;
            return customerTable.Rows.Count != 0 ? new Customers(customerTable.Rows[0]) : null;
        }

        public void AddNewCustomer(Customers newCustomer)
        {
            StringBuilder requstBuilder = new StringBuilder();
            requstBuilder.AppendFormat(InsertRequestTemplate, newCustomer.Surname, newCustomer.Name, newCustomer.Email, newCustomer.PhoneNumber);

            InsertQuery(requstBuilder.ToString());
        }

        public void DeleteCustomersById(int customerId)
        {
            StringBuilder requstBuilder = new StringBuilder();
            requstBuilder.AppendFormat(DeleteRequestTemplate, customerId);

            InsertQuery(requstBuilder.ToString());
        }
        #endregion
    }
}
