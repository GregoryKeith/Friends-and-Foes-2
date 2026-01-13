using System.ComponentModel.DataAnnotations;

namespace FriendsAndFoes2.Web.Models
{
    public class Banner
    {
        public int Id { get; set;}

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]

        public string Structure { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Domain{  get; set; } = string.Empty;

        public string OwnerUserId { get; set; } = string.Empty;

        public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;




    }
}
