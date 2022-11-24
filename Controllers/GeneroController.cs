using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class GeneroController : Controller
{
    private readonly MOTOMAMIContext_context;

    public GeneroController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Genero);
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Salvar([FromForm] Genero genero)
    {
        if(!ModelState.IsValid)
        {
            return View(Genero);
        }

        _context.Genero.Add(Generos)
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        Genero genero = _context.Genero.Find(id);

        if(genero == null)
        {
            return NotFound();
        }

        return View (genero);
    }

   public IActionResult Editar(int id)
   {
    Genero genero = _context.Genero.Find(id);

    if(genero == null)
    {
        return NotFound();
    }

    return View (genero);

   }

   public IActionResult Deletar(int id)
   {
    
    Genero genero = _context.Genero.Find(id);

    if(genero == null)
    {
        return NotFound();
    }

    _context.Genero.Remove(genero);
    _context.SaveChanges();

    return View();
   }
}