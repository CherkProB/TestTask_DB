using TestTask.BaseObjects;
using TestTask.DataBaseProviders.Base;

namespace TestTask.DataBaseProviders.MySQL
{
    public sealed class MySQLDBProvider : BaseDBProvider
    {
        #region Fields
        private readonly MySQLCustomersTableProvider customersTableProvider;
        private readonly MySQLOrdersTableProvider ordersTableProvider;
        #endregion

        #region Constructor
        public MySQLDBProvider(string connectionString, bool isDetailed = false)
        {
            customersTableProvider = new MySQLCustomersTableProvider(connectionString, "customers");
            ordersTableProvider = new MySQLOrdersTableProvider(connectionString, "orders");

            customersTableProvider.IsDetailed = isDetailed;
            ordersTableProvider.IsDetailed = isDetailed;
        }
        #endregion

        #region CheckConnection
        public override bool CheckConnection() => customersTableProvider.CheckConnection();
        #endregion

        #region SelectRequests
        public override Customers[] SelectAllCustomers() => customersTableProvider.SelectAllCustomers();
        public override Customers? SelectCustomerById(int customerId) => customersTableProvider.SelectCustomerById(customerId);
        public override Orders[] SelectAllOrders() => ordersTableProvider.SelectAllOrders();
        public override Orders? SelectOrderById(int orderId) => ordersTableProvider.SelectOrderById(orderId);
        public override Orders[] SelectAllOrdersByCustomerId(int customerId) => ordersTableProvider.SelectAllOrdersByCustomerId(customerId);
        #endregion

        #region AddRequests
        public override void AddNewCustomer(Customers newCustomer) => customersTableProvider.AddNewCustomer(newCustomer);
        public override void AddNewOrder(Orders newOrder) => ordersTableProvider.AddNewOrder(newOrder);
        #endregion

        #region DeleteRequests
        public override void DeleteCustomerById(int customerId) => customersTableProvider.DeleteCustomersById(customerId);
        public override void DeleteOrderById(int orderId) => ordersTableProvider.DeleteOrdersById(orderId);

        #endregion
    }
}
