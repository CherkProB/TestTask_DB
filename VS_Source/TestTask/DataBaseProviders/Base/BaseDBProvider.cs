using TestTask.BaseObjects;

namespace TestTask.DataBaseProviders.Base
{
    public abstract class BaseDBProvider
    {
        #region SelectRequests
        public abstract Customers[] SelectAllCustomers();
        public abstract Orders[] SelectAllOrders();
        public abstract Orders[] SelectAllOrdersByCustomerId(int customerId);
        #endregion

        #region AddRequests
        public abstract void AddNewCustomer(Customers newCustomer);
        public abstract void AddNewOrder(Orders newOrder);
        #endregion

        #region DeleteRequests
        public abstract void DeleteCustomersById(int customerId);
        public abstract void DeleteOrdersById(int orderId);
        #endregion
    }
}
