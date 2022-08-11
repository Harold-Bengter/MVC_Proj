using Microsoft.AspNetCore.Mvc;
using MVC_Proj.Models;

namespace MVC_Proj.Controllers
{
    public class ProductController : Controller
    {

        private readonly IProductRepository _repo;

        public ProductController(IProductRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var products = _repo.getAllProducts();
            return View(products);
        }
        public IActionResult InsertProduct()
        {
            var prod = _repo.AssignCategory();
            return View(prod);
        }

        public IActionResult InsertProductToDatabase(Product productToInsert)
        {
            _repo.InsertProduct(productToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult ViewProduct(int id)
        {
            var product = _repo.getProduct(id);
            return View(product);
        }

        public IActionResult UpdateProduct(int id)
        {
            Product prod =_repo.getProduct(id);
            if (prod == null)
            {
                return View("ProductNotFound");
            }
            return View(prod);
        }

        public IActionResult DeleteProduct(Product product)
        {
            _repo.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProductToDatabase(Product product)
        {
            _repo.UpdatePrpduct(product);

            return RedirectToAction ("ViewProduct", new { id = product.ProductID });
        }
    }
}
