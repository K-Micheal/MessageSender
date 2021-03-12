using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MessageSender.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(string exceptionMessage)
        {
            ViewBag.Error = exceptionMessage;
            return View();
        }
    }
}
