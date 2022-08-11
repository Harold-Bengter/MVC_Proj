using Dapper;
using MVC_Proj.Models;
using System.Data;
using Testing.Models;

namespace MVC_Proj;

public class ProductRepository : IProductRepository
{
    private readonly IDbConnection _conn;

    //Constructor injection. Add connection to database
    public ProductRepository(IDbConnection conn)
    {
        _conn = conn;
    }
    public Product AssignCategory()
    {
        var categoryList = GetCategories();
        var product = new Product();
        product.Categories = categoryList;
        return product;
    }

    public void DeleteProduct(Product product)
    {
        _conn.Execute("DELETE FROM REVIEWS WHERE ProductID = @id;", new { id = product.ProductID });
        _conn.Execute("DELETE FROM Sales WHERE ProductID = @id;", new { id = product.ProductID });
        _conn.Execute("DELETE FROM Products WHERE ProductID = @id;", new { id = product.ProductID });
    }

    public IEnumerable<Product> getAllProducts()
    {
        return _conn.Query<Product>("SELECT * FROM products");
    }

    public IEnumerable<Category> GetCategories()
    {
        return _conn.Query<Category>("SELECT * FROM categories;");
    }

    public Product getProduct(int id)
    {
        return _conn.QuerySingle<Product>("SELECT * FROM Products WHERE ProductID = @id", new { id });
    }

    public void InsertProduct(Product productToInsert)
    {
        _conn.Execute("INSERT INTO products (NAME, PRICE, CATEGORYID) VALUES (@name, @price, @categoryID);",
            new { name = productToInsert.Name, price = productToInsert.Price, categoryID = productToInsert.CategoryID });
    }

    public void UpdatePrpduct(Product product)
    {
        _conn.Execute("UPDATE products SET Name = @name, Price = @price WHERE ProductID = @id",
        new { name = product.Name, price = product.Price, id = product.ProductID });
    }
}
