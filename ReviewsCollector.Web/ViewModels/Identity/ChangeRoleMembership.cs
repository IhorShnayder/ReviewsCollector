using System.ComponentModel.DataAnnotations;

namespace ReviewsCollector.Web.ViewModels.Identity
{
    public class ChangeRoleMembership
    {
        [Required]
        public string RoleName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }
    }
}