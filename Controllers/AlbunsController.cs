using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class AlbunsController : Controller
{
    private readonly MOTOMAMIContext_context;

    public AlbunsController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Albuns);
    }

    public IActionResult Cadastro()
    {
        return View(); //Criar view de cadastro de albuns, pois a que está em uso no momento é a de músicas
    }

    public IActionResult Salvar([FromForm] Albuns albuns)
    {
        if(!ModelState.IsValid)
        {
            return View(Albuns); //Criar ums view de salvar albuns, pois a utilizada atualmente é a de músicas
        }

        _context.Albuns.Add(albuns);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id) //View utilizada atualmente é a de música
    {
        Albuns albuns = _context.Albuns.Find(id);

        if(albuns = null)
        {
            return NotFound();
        }

        return View(albuns);
    }

    public IActionResult Editar(int id) //View utilizada atualmente é a de música
    {
        Albuns albuns = _context.Albuns.Find(id);

        if(albuns == null)
        {
            return NotFound();

        }

        return View (albuns);
    }

    public IActionResult Deletar(int id)
    {
        Albuns albuns = _context.Albuns.Find(id);

        if(albuns == null)
        {
            return NotFound();
        }
        _context.Albuns.Remove(albuns);
        _context.SaveChanges();

        return View();
    }

}