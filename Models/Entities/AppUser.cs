using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities
{
    public class AppUser
    {
        public int Id { get; set; }

        [Required, MaxLength(1024)]
        public string FullName { get; set; }
        [Required, MaxLength(254)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }

        private bool? isActive;
        [Required]
        public bool IsActive
        {
            get { 
                if(isActive == null)
                    return true;
                return isActive.Value;
            }
            set { isActive = value; }
        }

        public ICollection<SaleOrder> SaleOrdersCreated { get; set; } = new List<SaleOrder>();
        public ICollection<SaleOrder> SaleOrdersUpdated { get; set; } = new List<SaleOrder>();

        public ICollection<SaleOrderLine> SaleOrderLines { get; set; } = new List<SaleOrderLine>();
        public ICollection<PurchaseOrder> PurchaseOrdersCreated { get; set; } = new List<PurchaseOrder>();
        public ICollection<PurchaseOrder> PurchaseOrdersUpdated { get; set; } = new List<PurchaseOrder>();

        public ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = new List<PurchaseOrderLine>();


    }
}
