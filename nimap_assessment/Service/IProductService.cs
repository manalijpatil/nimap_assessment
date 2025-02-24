using nimap_assessment.Models;

namespace nimap_assessment.Service
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProductById(int id);
        int AddProduct(Product product);
        int UpdateProduct(Product product);
        int DeleteProduct(int id);
    }
}
