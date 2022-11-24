using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class MusicaController : Controller
{
    private readonly MOTOMAMIContext _context;

    public MusicaController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Musicas);
    }
    
    public IActionResult Cadastro(){
        return View();
    }


    public IActionResult Salvar([FromForm] Musica musica)
    {
        if (!ModelState.IsValid)
        {
            return View(musica);

        }

        _context.Musicas.Add(musica);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}

