using Microsoft.AspNetCore.Mvc;
using MVC.Ass1.Models;
namespace MVC.Ass1.Controllers
{
    public class ProductsController : Controller
    {
        public ViewResult Index()
        {
            var result = new ViewResult();
            return result;

            return View();
        }

        //baseUrl/Products/GetJsonData
        //baseUrl/Json
        //[HttpGet("Json")]
        public JsonResult GetJsonData()
        {
            var products = new List<Product>()
            {
                new Product(){Id=1,Name="Laptop"},
                new Product(){Id=2,Name="PC"},
                new Product(){Id=3,Name="PS"},
                new Product(){Id=4,Name="Conditioner"},
            };

            return Json(products);
        }
        //BASEURL/Products/GetProducts/0
        //BASEURL/ProductsCode/1
        //[HttpGet("ProductCode/{id:int}")]
        public IActionResult GetProducts(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            if (id != 3)
            {
                return NotFound();
            }
            var products = new List<Product>()
            {
                new Product(){Id=1,Name="Laptop"},
                new Product(){Id=2,Name="PC"},
                new Product(){Id=3,Name="PS"},
                new Product(){Id=4,Name="Conditioner"},
            };

            return Json(products);
        }
        public RedirectToActionResult Redirect()
        {
            return RedirectToAction(nameof(GetProducts));
        }
        public RedirectResult RedirectToFacebook()
        {
            return Redirect("https://www.facebook.com/");
        }

        public ContentResult Content()
        {
            return Content("<h1>Hello from System<h1>", "text/html");
        }
        public FileResult DownloadFile()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "site.css");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "text/css", "MyCss.css");
        }

    }
}
