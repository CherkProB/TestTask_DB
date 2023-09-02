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
            var cells = row.ItemArray;

            id = int.Parse(cells[0].ToString());
            title = cells[1].ToString();
            orderDate = cells[2].ToString();
            price = int.Parse(cells[3].ToString());
            customerId = int.Parse(cells[4].ToString());
        }
        /*
        */
        /*
        public Orders(DataRow row)
        {
            string[] cells = row.ItemArray.Cast<string>().ToArray();

            id = int.Parse(cells[0].ToString());
            title = cells[1].ToString();
            orderDate = cells[2].ToString();
            price = int.Parse(cells[3].ToString());
            customerId = int.Parse(cells[4].ToString());
        }
        */
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
