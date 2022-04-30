using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class CommentDto
    {
        public int? CommentLineID { get; set; }
        [Required]
        public string Comment { get; set; }

    }
}
