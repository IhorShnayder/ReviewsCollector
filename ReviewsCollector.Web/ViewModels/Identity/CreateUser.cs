using System.ComponentModel.DataAnnotations;

namespace ReviewsCollector.Web.ViewModels.Identity
{
    public class CreateUser
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}