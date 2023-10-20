using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp_DB_
{
    public struct Order: ISqlObject
    {
        public long ConsignmentNumber { get; set; }
        public string Product { get; set; }
        public decimal Price { get; set; }
        public double Amount { get; set; }
        public string UnitType { get; set; }
        public double TotalPrice { get; set; }

        public void ReadFromRecord(IDataRecord reader)      //Factory, Creator
        {
            ConsignmentNumber = reader.GetInt64(0);
            Product = reader.GetString(1);
            Price = reader.GetDecimal(2);
            Amount = reader.GetDouble(3);
            UnitType = reader.GetString(4);
            TotalPrice = reader.GetDouble(5);
        }

    }
}
