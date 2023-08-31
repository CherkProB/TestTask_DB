using TestTask.BaseObjects;
using TestTask.DataBaseProviders.Base;

namespace TestTask.DataBaseProviders.MySQL
{
    public class MySQLDBProvider : BaseDBProvider
    {
        #region Declaration
        public override BaseTableProvider CustomerTableProvider { get => customersTableProvider; }
        private readonly MySQLCustomersTableProvider customersTableProvider;

        public override BaseTableProvider OrderTableProvider { get => ordersTableProvider; }
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

        #region SelectRequests
        public override Customers[] SelectAllCustomers() => customersTableProvider.SelectAllCustomers();
        public override Orders[] SelectAllOrders() => ordersTableProvider.SelectAllOrders();
        public override Orders[] SelectAllOrdersByCustomerId(int customerId) => ordersTableProvider.SelectAllOrdersByCustomerId(customerId);
        #endregion

        #region AddRequests
        public override void AddNewCustomer(Customers newCustomer) => customersTableProvider.AddNewCustomer(newCustomer);
        public override void AddNewOrder(Orders newOrder) => ordersTableProvider.AddNewOrder(newOrder);
        #endregion

        #region DeleteRequests
        public override void DeleteCustomersById(int customerId) => customersTableProvider.DeleteCustomersById(customerId);
        public override void DeleteOrdersById(int orderId) => ordersTableProvider.DeleteOrdersById(orderId);
        #endregion
    }
}
