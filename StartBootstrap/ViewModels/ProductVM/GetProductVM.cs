using StartBootstrap.Models;

namespace StartBootstrap.ViewModels.ProductVM
{
    public class GetProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
  
    
        public Category Category { get; set; }
    }
}
