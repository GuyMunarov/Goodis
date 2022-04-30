using Models.Entities;
using Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class OrderToCreateDto
    {
        [Required]
        public int OrderType { get; set; }
        [Required]
        public OrderDataDto Data { get; set; }


        public class OrderDataDto
        {
            public int Id { get; set; }
            [Required]
            public List<GetLineDto> Lines { get; set; } = new List<GetLineDto>();

            public string? CreatedByName { get; set; }
            public string? LastUpdatedByName { get; set; }
            public int? CreatedById { get; set; }

            public int? LastUpdatedById { get; set; }

            public DateTime? CreateDate { get; set; }

            public DateTime? LastUpdateDate { get; set; }
            public BusinessPartnerDto? BusinessPartner { get; set; }

            [Required]
            public string BpCode { get; set; }

        }

       

    }

}