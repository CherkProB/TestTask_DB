﻿using System.Data;
using System.Text;

namespace TestTask.BaseObjects
{
    public class Customers
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
            string[] cells = (string[])row.ItemArray;

            id = int.Parse(cells[0].ToString());
            surname = cells[1].ToString();
            name = cells[2].ToString();
            email = cells[3].ToString();
            phoneNumber = double.Parse(cells[4].ToString());
        }
        #endregion

        #region Method
        public string[] GetStringArray() => new string[] {id.ToString(), surname, name, email, phoneNumber.ToString()};
        #endregion

        #region Override
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append(id + ": ");
            stringBuilder.Append(name + " ");
            stringBuilder.Append(surname + ". ");
            stringBuilder.Append("Email: " + email + ". ");
            stringBuilder.Append("Phone Number: " + phoneNumber + ".");

            return stringBuilder.ToString();
        }
        #endregion
    }
}
