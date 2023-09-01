using TestTask.BaseObjects;

namespace TestTask.DataBaseProviders.Base
{
    public abstract class BaseDBProvider
    {
        #region CheckConnection
        public abstract bool CheckConnection();
        #endregion

        #region SelectRequests
        public abstract Customers[] SelectAllCustomers();
        public abstract Customers? SelectCustomerById(int customerId);
        public abstract Orders[] SelectAllOrders();
        public abstract Orders? SelectOrderById(int orderId);
        public abstract Orders[] SelectAllOrdersByCustomerId(int customerId);
        #endregion

        #region AddRequests
        public abstract void AddNewCustomer(Customers newCustomer);
        public abstract void AddNewOrder(Orders newOrder);
        #endregion

        #region DeleteRequests
        public abstract void DeleteCustomerById(int customerId);
        public abstract void DeleteOrderById(int orderId);
        #endregion
    }
}
