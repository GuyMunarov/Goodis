using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class BusinessPartnerDto
    {
        [Required]
        public string BpCode { get; set; }
        public string BPName { get; set; }
        public BpTypeDto BpType { get; set; }
        public bool Active { get; set; } = true;
    }

}
