using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StoreService
{
    public static class TotalPriceChangeManager
    {
        public delegate void TotalPriceChanged(double persentage, PriceChanging option);
        public static TotalPriceChanged EventHandler;
    }
}
