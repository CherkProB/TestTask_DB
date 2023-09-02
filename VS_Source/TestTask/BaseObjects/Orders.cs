using System.Data;
using System.Text;

namespace TestTask.BaseObjects
{
    public sealed class Orders
    {
        #region FieldsAndProperties
        public int Id { get => id; set => id = Math.Max(0, value); }
        private int id;

        public string Title { get => title; set => title = value; }
        private string title;

        public string OrderDate { get => orderDate; set => orderDate = value; }
        private string orderDate;

        public int Price { get => price; set => price = Math.Max(0, value); }
        private int price;

        public int CustomerId { get => customerId; set => customerId = Math.Max(0, value); }
        private int customerId;
        #endregion

        #region Constructors
        public Orders() 
        {
            id = price = customerId = 0;
            title = orderDate = string.Empty;
        }
        public Orders(DataRow row)
        {
            object?[] rowItems = row.ItemArray;

            int[] intArray = rowItems.OfType<int>().ToArray();
            string[] strArray = rowItems.OfType<string>().ToArray();

            id = 0 < intArray.Length ? intArray[0] : 0;
            title = 0 < strArray.Length ? strArray[0] : string.Empty;
            orderDate = 1 < strArray.Length ? strArray[1] : string.Empty;
            price = 1 < intArray.Length ? intArray[1] : 0;
            customerId = 2 < intArray.Length ? intArray[2] : 0;
        }
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("ID: ");
            stringBuilder.Append(id);
            stringBuilder.Append(". Title: ");
            stringBuilder.Append(title);
            stringBuilder.Append(". Order Date: ");
            stringBuilder.Append(orderDate);
            stringBuilder.Append(". Price: ");
            stringBuilder.Append(price);
            stringBuilder.Append(". Customer ID: ");
            stringBuilder.Append(customerId);

            return stringBuilder.ToString();
        }
        #endregion
    }
}
