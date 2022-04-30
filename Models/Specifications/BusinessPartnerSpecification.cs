using Models.Entities;
using Models.Specifications.SpecificationsParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class BusinessPartnerSpecification : BaseSpecification<BusinessPartner>
    {
        public BusinessPartnerSpecification(BusinessPartnerSpecParams itemParams, bool applyPaging = true)
            : base(x =>
            (string.IsNullOrEmpty(itemParams.BPName) || itemParams.BPName == x.BPName) &&
            (string.IsNullOrEmpty(itemParams.BpCode) || itemParams.BpCode == x.BpCode) &&
            (string.IsNullOrEmpty(itemParams.BpTypeCode) || itemParams.BpTypeCode == x.BpType.TypeCode) &&
            (itemParams.Active == null || itemParams.Active == x.Active))
        {
            AddInclude(x => x.BpType);

            if(applyPaging)
                ApplyPaging(itemParams.PageSize * (itemParams.PageIndex - 1), itemParams.PageSize);

        }

        public BusinessPartnerSpecification(string code): base(x => x.BpCode == code)
        {
            AddInclude(x => x.BpType);

        }
    }
}
