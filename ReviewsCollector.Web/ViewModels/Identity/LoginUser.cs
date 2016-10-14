using System.ComponentModel.DataAnnotations;

namespace ReviewsCollector.Web.ViewModels.Identity
{
    public class LoginModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }
    }

}