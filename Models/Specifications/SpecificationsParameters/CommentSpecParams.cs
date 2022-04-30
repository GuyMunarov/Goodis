using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Specifications.SpecificationsParameters
{
    public class CommentSpecParams
    {
        public int LineId { get; set; }
        public CommentSpecParams(int lineId)
        {
            LineId = lineId;
        }
    }
}
