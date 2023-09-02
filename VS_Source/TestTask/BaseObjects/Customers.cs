using System.Data;
using System.Text;

namespace TestTask.BaseObjects
{
    public sealed class Customers
    {
        #region FieldsAndProperties
        public int Id { get => id; set => id = Math.Max(0, value); }
        private int id;

        public string Surname { get => surname; set => surname = value; }
        private string surname;

        public string Name { get => name; set => name = value; }
        private string name;

        public string Email { get => email; set => email = value; }
        private string email;

        public double PhoneNumber { get => phoneNumber; set => phoneNumber = Math.Clamp(value, 80000000000, 89999999999); }
        private double phoneNumber;
        #endregion

        #region Constructors
        public Customers() 
        {
            id = 0;
            surname = name = email = string.Empty;
            phoneNumber = 80000000000;
        }

        public Customers(DataRow row) 
        {
            object?[] rowItems = row.ItemArray;

            int[] intArray = rowItems.OfType<int>().ToArray();
            string[] strArray = rowItems.OfType<string>().ToArray();
            double[] doubleArray = rowItems.OfType<double>().ToArray();

            id = 0 < intArray.Length ? intArray[0] : 0;
            surname = 0 < strArray.Length ? strArray[0] : string.Empty;
            name = 1 < strArray.Length ? strArray[1] : string.Empty;
            email = 2 < strArray.Length ? strArray[2] : string.Empty;
            phoneNumber = 0 < doubleArray.Length ? doubleArray[0] : 0;
        }
        #endregion

        #region Method
        private static string GetNumberInFormat(double phoneNumber) 
        {
            string phoneNumberStr = phoneNumber.ToString();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(phoneNumberStr.Substring(0, 1));
            stringBuilder.Append(" (");
            stringBuilder.Append(phoneNumberStr.Substring(1, 3));
            stringBuilder.Append(") ");
            stringBuilder.Append(phoneNumberStr.Substring(4, 3));
            stringBuilder.Append("-");
            stringBuilder.Append(phoneNumberStr.Substring(7, 2));
            stringBuilder.Append("-");
            stringBuilder.Append(phoneNumberStr.Substring(9, 2));

            return stringBuilder.ToString();

        }
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("ID: ");
            stringBuilder.Append(id);
            stringBuilder.Append(". Full Name: ");
            stringBuilder.Append(name);
            stringBuilder.Append(" ");
            stringBuilder.Append(surname);
            stringBuilder.Append(". Email: ");
            stringBuilder.Append(email);
            stringBuilder.Append(". Phone Number: ");
            stringBuilder.Append(GetNumberInFormat(phoneNumber));

            return stringBuilder.ToString();
        }
        #endregion
    }
}
