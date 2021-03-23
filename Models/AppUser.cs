using System.ComponentModel.DataAnnotations;

namespace DatingApi.Models
{
    public class AppUser
    {
        public int Id { get; set; }
        public string Username { get; set; }
    }
}
