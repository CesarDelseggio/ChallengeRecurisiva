using ChallengeRecursiva.Business.Interfaces;
using ChallengeRecursiva.WebMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeRecursiva.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IImportServices _importServices;

        public HomeController(ILogger<HomeController> logger, IImportServices importServices)
        {
            _logger = logger;
            _importServices = importServices;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    var filePath = Path.Combine(Environment.CurrentDirectory, "wwwroot/App_Data/socios.csv");

                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return View("UploadComplete");
                }
                else
                {
                    ViewBag.Message = "El archivo no contiene información";
                    return View("Error");
                }
            }
            catch (Exception)
            {
                ViewBag.Message = "Se produjo un error al intentar guardar el archivo";
                return View("Error");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Process()
        
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, "wwwroot/App_Data");
            var fileName = "socios.csv";

            await _importServices.ImportPartners(filePath,fileName);
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
