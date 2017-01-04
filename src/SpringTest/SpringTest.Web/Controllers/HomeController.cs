using System.Web.Mvc;

namespace SpringTest.Web.Controllers {
	public class HomeController : Controller
    {       
        public ActionResult Index()
        {
            return View();
        }
    }
}