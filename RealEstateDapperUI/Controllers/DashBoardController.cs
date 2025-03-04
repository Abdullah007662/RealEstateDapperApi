using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
