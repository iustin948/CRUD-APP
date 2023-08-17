using System.ComponentModel.DataAnnotations;

namespace APP.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }  = decimal.Zero;
       
        
    }
    
}
