using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LaCuevita.Areas.Seller.Controllers
{
    [Area("Seller")]
    public class SellerMainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}