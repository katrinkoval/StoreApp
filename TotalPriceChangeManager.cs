using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreApp_DB_
{
    public static class TotalPriceChangeManager
    {
        public delegate void TotalPriceChanged(double persentage, PriceChanging option);
        public static TotalPriceChanged EventHandler;
    }
}
