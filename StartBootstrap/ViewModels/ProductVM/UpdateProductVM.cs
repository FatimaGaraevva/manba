using StartBootstrap.Models;

namespace StartBootstrap.ViewModels.ProductVM
{
    public class UpdateProductVM
    {
        public string Name { get; set; }
        public string Image { get; set; }
   
        public Category Category { get; set; }
    }
}
