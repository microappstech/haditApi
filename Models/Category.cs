using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace haditApi.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.Now;

        [Required]
        [RegularExpression(@"^[\u0600-\u06FF\s]+$", ErrorMessage = "The field should be Arabic")]
        public string Name { get; set; } = null!;
        public IEnumerable<Hadit>? Hadits { get; set; }

    }

}
