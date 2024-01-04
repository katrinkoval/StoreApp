using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsDTO
{
    public class Consignment
    {
        public long Number { get; set; }

        public DateTime ConsignmentDate { get; set; }

        public string SupplierName { get; set; }

        public string RecipientName { get; set; }

        public int SupplierIpn { get; set; }

        public int RecipientIpn { get; set; }

    }
}
