
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace BookASP.Model
{
    public class Category
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [DisplayName("Name")]
        public string? Name { get; set; }
        [DisplayName("Display Order")]
        [Range(0, 1000, ErrorMessage = "0-1000")]
        public int DisplayOrder { get; set; }

    }
}
