using Models.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class BaseOrder: InstanceEntity, IOrder
    {
        public int Id { get; set; }

        [Required, MaxLength(128)]
        [ForeignKey("BusinessPartner")]
        public string BpCode { get; set; }

        public BusinessPartner? BusinessPartner { get; set; }
        [ForeignKey("LastUpdatedBy")]
        public int? LastUpdatedById{get; set; }
        public AppUser? LastUpdatedBy { get; set; }

        [ForeignKey("CreatedBy")]

        public int CreatedById { get; set; }
        public AppUser CreatedBy { get; set; }


        
    }
}
