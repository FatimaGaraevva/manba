using StartBootstrap.Models;
using System.ComponentModel.DataAnnotations;

namespace StartBootstrap.ViewModels.ProductVM
{
    public class UpdateProductVM
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public Category Category { get; set; }
      
        public IFormFile? NewPhoto { get; set; }
        [Required]
        public decimal? Price { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
    }
}

