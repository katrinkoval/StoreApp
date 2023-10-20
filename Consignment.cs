using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp_DB_
{
    public struct Consignment : ISqlObject
    {
        public long Number { get; set; }

        public DateTime ConsignmentDate { get; set; }

        public string SupplierName { get; set; }

        public string RecipientName { get; set; }

        public void ReadFromRecord(IDataRecord reader)
        {
            Number = reader.GetInt64(0);
            ConsignmentDate = reader.GetDateTime(1);
            SupplierName = reader.GetString(2);
            RecipientName = reader.GetString(3);
        }
    }
}
