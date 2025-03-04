using Microsoft.AspNetCore.Mvc;

namespace RealEstateDapperUI.ViewComponents.DashBoard
{
    public class _DashBoardChartPartial:ViewComponent
    {
        
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
