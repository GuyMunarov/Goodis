using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Interfaces
{
    public interface IOrder
    {

        public string BpCode { get; set; }

        public BusinessPartner? BusinessPartner { get; set; }
        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }
        public int CreatedById { get; set; }

        public AppUser CreatedBy { get; set; }
        public int? LastUpdatedById { get; set; }

        public AppUser? LastUpdatedBy { get; set; }
    }
}
