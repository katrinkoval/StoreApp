using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp_DB_
{
    interface ISqlObject
    {
        void ReadFromRecord(IDataRecord reader);
        
    }
}
