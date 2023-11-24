using Microsoft.AspNetCore.Mvc;

namespace Pustok_Temp.Areas.PustokAdmin.Controllers
{
    [Area("PustokAdmin")]
    public class DashboardController:Controller
    {



        public IActionResult Index()
        {
            return View();
        }

    }
}
