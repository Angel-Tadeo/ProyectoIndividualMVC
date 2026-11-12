using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ProyectoIndividualMVC.Models;

namespace ProyectoIndividualMVC.Controllers;

public class ProductosController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
