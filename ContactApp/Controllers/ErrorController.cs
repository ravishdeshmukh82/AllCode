using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactApp.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{StatusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewBag.errorMessage = "Resource you requested could not be found";
                    break;
                
            }
            return View("ErrorPage");
        }

        [Route("Error")]
        [AllowAnonymous]
        public string Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            return "";
        }
    }
}
