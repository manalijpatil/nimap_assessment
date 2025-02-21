using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace nimap_assessment.Models
{

    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string? ProductName { get; set; }
        public int CategoryId { get; set; }

       
        public String? CategoryName { get; set; }
    }
}
