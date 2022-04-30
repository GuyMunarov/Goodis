using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications.SpecificationsParameters
{
    public class ItemSpecParams
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? ItemCode { get; set; }
        public string? ItemName { get; set; }
        public bool? Active { get; set; }



    }
}
