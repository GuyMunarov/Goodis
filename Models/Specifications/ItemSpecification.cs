using Models.Entities;
using Models.Specifications.SpecificationsParameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications
{
    public class ItemSpecification : BaseSpecification<Item>
    {
        public ItemSpecification(ItemSpecParams itemParams, bool applyPaging = true)
            : base(x =>
            (string.IsNullOrEmpty(itemParams.ItemCode) || itemParams.ItemCode == x.ItemCode) &&
            (string.IsNullOrEmpty(itemParams.ItemName) || itemParams.ItemName == x.ItemName) &&
            (itemParams.Active == null || itemParams.Active == x.Active))
        {
                if(applyPaging)
                ApplyPaging(itemParams.PageSize * (itemParams.PageIndex - 1), itemParams.PageSize);

        }
        public ItemSpecification(string itemCode): base(x => x.ItemCode == itemCode)
        {

        }

    }
}
