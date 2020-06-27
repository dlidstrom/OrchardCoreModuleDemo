using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using OrchardCore.DisplayManagement.Notify;

namespace Workshop.Demo.Module.Controllers
{
    // http://localhost:5000/Workshop.Demo.Module/Home/Index
    // http://localhost:5000/Home/Index
    public class HomeController : Controller
    {
        private readonly INotifier notifier;
        private readonly IHtmlLocalizer<HomeController> H;
        private readonly IStringLocalizer<HomeController> T;
        private readonly ILogger<HomeController> L;

        public HomeController(
            INotifier notifier,
            IHtmlLocalizer<HomeController> htmlLocalizer,
            IStringLocalizer<HomeController> stringLocalizer,
            ILogger<HomeController> logger)
        {
            this.notifier = notifier;
            this.H = htmlLocalizer;
            this.T = stringLocalizer;
            this.L = logger;
        }

        public ActionResult Index()
        {
            notifier.Success(H["Hi stranger!"]);
            return View();
        }

        [Route("Log")]
        public string Log()
        {
            L.LogError("Oh no!");
            return "Successfully logged.";
        }
    }
}
