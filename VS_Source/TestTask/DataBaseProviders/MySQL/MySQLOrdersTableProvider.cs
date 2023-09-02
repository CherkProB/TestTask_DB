using System.Data;
using System.Text;
using TestTask.BaseObjects;

namespace TestTask.DataBaseProviders.MySQL
{
    public sealed class MySQLOrdersTableProvider : MySQLTableProvider
    {
        #region RequestTemplates
        private const string SelectRequestTemplate = @"SELECT * FROM `orders` WHERE `id_order` = {0}";
        private const string SelectCustomerRequestTemplate = @"SELECT * FROM `orders` WHERE `id_customer` = {0}";
        private const string InsertRequestTemplate = @"INSERT INTO `orders`(`title`, `order_date`, `order_price`, `id_customer`) VALUES ('{0}',CURRENT_DATE,'{1}','{2}')";
        private const string DeleteRequestTemplate = @"DELETE FROM `orders` WHERE `id_order` = {0}";
        #endregion

        #region Constructor
        public MySQLOrdersTableProvider(string connectionString, string tableName) :
            base(connectionString, tableName)
        { }
        #endregion

        #region Requests
        public Orders[] SelectAllOrders()
        {
            List<Orders> orders = new List<Orders>();
            DataTable? ordersTable = SelectAll();

            if (ordersTable != null)
                foreach (DataRow row in ordersTable.Rows)
                    orders.Add(new Orders(row));

            return orders.ToArray();
        }

        public Orders? SelectOrderById(int orderId)
        {
            StringBuilder requstBuilder = new StringBuilder();
            requstBuilder.AppendFormat(SelectRequestTemplate, orderId);

            DataTable? orderTable = Select(requstBuilder.ToString());

            if (orderTable == null) return null;
            return orderTable.Rows.Count != 0 ? new Orders(orderTable.Rows[0]) : null;
        }

        public Orders[] SelectAllOrdersByCustomerId(int customerId)
        {
            List<Orders> orders = new List<Orders>();

            StringBuilder requestBuilder = new StringBuilder();
            requestBuilder.AppendFormat(SelectCustomerRequestTemplate, customerId);

            DataTable? ordersTable = Select(requestBuilder.ToString());

            if (ordersTable != null)
                foreach (DataRow row in ordersTable.Rows)
                    orders.Add(new Orders(row));

            return orders.ToArray();
        }

        public void AddNewOrder(Orders newOrder)
        {
            StringBuilder requstBuilder = new StringBuilder();
            requstBuilder.AppendFormat(InsertRequestTemplate, newOrder.Title, newOrder.Price, newOrder.CustomerId);

            InsertQuery(requstBuilder.ToString());
        }

        public void DeleteOrdersById(int orderId)
        {
            StringBuilder requstBuilder = new StringBuilder();
            requstBuilder.AppendFormat(DeleteRequestTemplate, orderId);

            InsertQuery(requstBuilder.ToString());
        }
        #endregion
    }
}
