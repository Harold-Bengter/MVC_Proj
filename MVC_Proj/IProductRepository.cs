using MVC_Proj.Models;
using Testing.Models;

namespace MVC_Proj;

public interface IProductRepository
{
    public IEnumerable<Product> getAllProducts();
    public Product getProduct(int id);
    public void UpdatePrpduct(Product product);
    public void InsertProduct(Product productToInsert);
    public IEnumerable<Category> GetCategories();
    public Product AssignCategory();
    public void DeleteProduct(Product product);
}