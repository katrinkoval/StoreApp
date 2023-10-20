using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp_DB_
{
    public struct Product: ISqlObject
    {
        public string Name { get; set; }
        public string UnitType { get; set; }

        public void ReadFromRecord(IDataRecord reader)      //Factory, Creator
        {
            Name = reader.GetString(0);
            UnitType = reader.GetString(1);
        }
    }
}
