using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace haditApi.Models
{
    public class Hadit
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "The field must contain only Arabic letters.")]
        [Required(ErrorMessage = "The content are required")]
        public string Content { get; set; } = null!;
        public DateTime AddedAt { get; set; } = DateTime.Now;
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "The field must contain only Arabic letters.")]
        public string OnPublisher { get; set; } = null!;
        
        public int CategoryId { get; set; }
        [JsonIgnore] public Category? Category { get; set; }
        [JsonIgnore]public bool Confirmed { get; set; }
    }
}
