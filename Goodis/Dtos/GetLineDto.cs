using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class GetLineDto: LineToReturnDto
    {
      
        public string? ItemName { get; set; }
        public string? IsItemActive { get; set; }
      
    }
}
