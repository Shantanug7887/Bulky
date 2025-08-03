using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BulkyWebRezor.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(35)]
        [DisplayName("Category Nams")]
        public string Name { get; set; }


        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Pleas Correct the Input")]
        public int DisplayOrder { get; set; }

    }
}
