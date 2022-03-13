using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using appcalculadora.Models;

namespace appcalculadora.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult result(Operacion operacion)
    {
        ViewData["result"] = "La " + this.getType(operacion) + " es: "  + this.resolver(operacion);
        return View("Index");
    }

    private double resolver(Operacion operacion)
    {
        switch (operacion.Type)
        {
            case 'S': 
                return operacion.Number1 + operacion.Number2;
            case 'R': 
                return operacion.Number1 - operacion.Number2;
            case 'M': 
                return operacion.Number1 * operacion.Number2;
            case 'D': 
                return operacion.Number1 / operacion.Number2;

            default: 
                return 0.0;
        }
    }

   private string getType(Operacion operacion)
    {
        switch (operacion.Type)
        {
            case 'S': return "suma";
            case 'R': return "resta";
            case 'M': return "multiplicacion";
            case 'D': return "division";
            default:  return "=(";
        }
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
