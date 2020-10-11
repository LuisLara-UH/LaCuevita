using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LaCuevita.Areas.Client.Controllers
{
    [Area("Client")]
    public class ClientMainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}