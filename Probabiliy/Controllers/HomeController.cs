using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Probability.Models;

namespace Probability.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string probA, string probB, string result, string calculationType)
        {
            Calculation calc = new Calculation( probA,  probB,  result,  calculationType);

            CalculationLogger logger = new CalculationLogger(calc);

            logger.log();

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

    }
}
