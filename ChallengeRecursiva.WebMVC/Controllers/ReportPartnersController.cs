using ChallengeRecursiva.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ChallengeRecursiva.WebMVC.Controllers
{
    public class ReportPartnersController : Controller
    {
        private IReportPartnerServices _reportPartnerServices;
        public ReportPartnersController(IReportPartnerServices reportPartnerServices)
        {
            _reportPartnerServices = reportPartnerServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Exercise1()
        {
            var result = await _reportPartnerServices.Exercise1();
            return View(result);
        }

        public IActionResult Exercise2()
        {
            var result = _reportPartnerServices.Exercise2();
            return View(result);
        }

        public IActionResult Exercise3()
        {
            var result = _reportPartnerServices.Exercise3();
            return View(result);
        }

        public IActionResult Exercise4()
        {
            var result = _reportPartnerServices.Exercise4();
            return View(result);
        }
        public IActionResult Exercise5()
        {
            var result = _reportPartnerServices.Exercise5();
            return View(result);
        }
    }
}
