using Microsoft.AspNetCore.Mvc;

namespace YourProjectName.Controllers
{
    public class BlogController : Controller
    {
        public ActionResult Index()
        {
            // Add your blog logic here
            return View();
        }
    }
}
