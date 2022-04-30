using System.ComponentModel.DataAnnotations;

namespace Goodis.Dtos
{
    public class RegisterDto
    {

        [Required, MaxLength(1024)]
        public string FullName { get; set; }
        [Required, MaxLength(254)]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }


    }
}
