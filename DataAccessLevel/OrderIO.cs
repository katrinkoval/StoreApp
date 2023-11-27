using System;
using System.Data;
using Models;

namespace DataAccessLevel
{
    public struct OrderIO : ISqlObject<Order>
    {
        public Order ReadFromRecord(IDataRecord reader)
        {
            Order ord = new Order();

            ord.ConsignmentNumber = Convert.ToInt64(reader["ConsignmentNumber"]);  //reader.GetInt64(0);
            ord.Product = reader["Name"].ToString();                               //reader.GetString(1);
            ord.Price = Convert.ToDecimal(reader["Price"]);                        //reader.GetDecimal(2);
            ord.Amount = Convert.ToDouble(reader["Amount"]);                               //reader.GetDouble(3);
            ord.UnitType = reader["UnitType"].ToString();                          //reader.GetString(4);
            ord.TotalPrice = Convert.ToDouble(reader["TotalPrice"]);               //reader.GetDouble(5);

            return ord;
        }
    }
}
