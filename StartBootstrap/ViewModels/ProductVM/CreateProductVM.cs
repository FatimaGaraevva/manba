using StartBootstrap.Models;
using System.ComponentModel.DataAnnotations;

namespace StartBootstrap.ViewModels.ProductVM
{
    public class CreateProductVM
    {
        public string Name { get; set; }
        public IFormFile? MainPhoto { get; set; }

        public int? CategoryId { get; set; }
        public List< Category> Categories { get; set; }
        [Required]
        public decimal? Price { get; set; }
    }
}
