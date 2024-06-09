using Proyecto_NET.Data;
using Proyecto_NET.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Proyecto_NET.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new AdventureWorksLT2022())
            {

                var query = from p in ctx.Products
                            orderby p.ProductID
                            select p;

                var resultados = query.ToList();
                return View(resultados);
            }
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