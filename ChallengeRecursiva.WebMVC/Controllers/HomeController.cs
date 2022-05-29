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

        private string _filePath = Path.Combine(Environment.CurrentDirectory, "wwwroot/App_Data");
        private string _fileName = "socios.csv";
        private string _fullFilePath;
        public HomeController(ILogger<HomeController> logger, IImportServices importServices, ILogService logService)
        {
            _logger = logger;
            _importServices = importServices;

            _fullFilePath = Path.Combine(_filePath, _fileName);

            logService.Get(1).Wait();
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
                if (file == null || file.Length <= 0)
                    return View("Error", "El archivo no contiene información");

                using (var stream = System.IO.File.Create(_fullFilePath))
                {
                    await file.CopyToAsync(stream);
                }

                if (await _importServices.ImportPartners(_filePath, _fileName) == false)
                    return View("Error", "No se pudo procesar el archivo, verifique que sea el formato correcto");

                return RedirectToAction("Index", "ReportPartners");
            }
            catch (Exception ex)
            {
                return View("Error", "Se produjo un error al intentar guardar el archivo");    
            }
        }


        //Default actions
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
