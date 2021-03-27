using System.ComponentModel.DataAnnotations;

namespace DatingApi.Dtos
{
    public class UserBaseDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
