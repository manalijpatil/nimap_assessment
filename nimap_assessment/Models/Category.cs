using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace nimap_assessment.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {  get; set; }
        [Required]
        public string? CategoryName { get; set; }
    }
}
