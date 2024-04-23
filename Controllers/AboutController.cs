using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class AboutController : Controller
    {
        public ActionResult Index()
        {
            // Add your about page logic here
            return View();
        }
    }
}
