using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications.SpecificationsParameters
{
    public class BusinessPartnerSpecParams
    {
        public int PageIndex { get; set; } = 1;
        public int PageSize { get; set; } = 10;

        public string? BpCode { get; set; }
        public string? BPName { get; set; }
        public string? BpTypeCode { get; set; }
        public bool? Active { get; set; }



    }
}
