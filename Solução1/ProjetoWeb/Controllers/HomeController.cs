using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjetoWeb.Models;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace ProjetoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpPost("uploads")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewData["ErrorMessage"] = "Por favor, selecione um arquivo para fazer upload.";
                return View("Index");
            }
            else
            {
                // Lógica para processar o arquivo
                // Se o upload for bem-sucedido
                ViewData["SuccessMessage"] = "O arquivo foi enviado com sucesso!";
                return View("Index");
            }
        }

    }
}
    


