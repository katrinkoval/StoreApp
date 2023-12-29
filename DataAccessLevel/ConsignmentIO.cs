using Models;
using System;
using System.Data;

namespace DataAccessLevel
{
    public struct ConsignmentIO : ISqlObject<Consignment>
    {
        public Consignment ReadFromRecord(IDataRecord reader)
        {
            Consignment cons = new Consignment();

            cons.Number = Convert.ToInt64(reader["Number"]);                              //reader.GetInt64(0);
            cons.ConsignmentDate = Convert.ToDateTime(reader["ConsignmentDate"]);         //reader.GetDateTime(1);
            cons.SupplierName = reader["Supplier"].ToString();                            //reader.GetString(2);
            cons.RecipientName = reader["Recipient"].ToString();                          //reader.GetString(3);

            return cons;
        }
    }
   
}
