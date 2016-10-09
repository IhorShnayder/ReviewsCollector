using ReviewsCollector.Domain.Entities.Enums;
using System.ComponentModel.DataAnnotations;

namespace ReviewsCollector.Domain.Entities
{
    public class Review : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Content { get; set; }

        public EntityStatusEnum Status { get; set; }
    }
}
