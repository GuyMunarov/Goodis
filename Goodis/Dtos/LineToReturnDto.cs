using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class LineToReturnDto
    {
        public int LineID { get; set; }
        public int DocID { get; set; }

        [Required]
        public string ItemCode { get; set; }
        public int CreatedById { get; set; }

        public int? LastUpdatedById { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? LastUpdateDate { get; set; }

        [Required]
        public decimal Quantity { get; set; }

        public List<CommentDto>? Comments { get; set; } = new List<CommentDto>();
    }
}
