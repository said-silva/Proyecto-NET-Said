using Proyecto_NET.Data.Entities;
using Proyecto_NET.Service;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Proyecto_NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var productService = new ProductsService();
            List<Product> resultados = productService.getProducts(null);
            return View(resultados);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}