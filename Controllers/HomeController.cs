using Microsoft.AspNetCore.Mvc;

namespace VisitorsBlog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Add your home page logic here
            return View();
        }
    }
}
