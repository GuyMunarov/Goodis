using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class OrderToReturnDto
    {
        public int Id { get; set; }
        [Required]
        public List<LineToReturnDto> Lines { get; set; } = new List<LineToReturnDto>();

        public int? CreatedById { get; set; }

        public int? LastUpdatedById { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [Required]
        public string BpCode { get; set; }
    }
}
