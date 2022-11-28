using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class OuvinteController : Controller
{
    private readonly MOTOMAMIContext _context;

    public OuvinteController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Ouvintes);
    }

    public IActionResult Cadastro()
    {
        return View(); 
    }

    public IActionResult Salvar([FromForm] Ouvinte ouvinte)
    {
        if(!ModelState.IsValid)
        {
            return View(ouvinte); 

        _context.Ouvintes.Add(ouvinte);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id) //View utilizada atualmente é a de música
    {
        Ouvinte ouvinte = _context.Ouvintes.Find(id);

        if(ouvinte == null)
        {
            return NotFound();
        }

        return View(ouvinte);
    }

    public IActionResult Editar(int id) //View utilizada atualmente é a de música
    {
        Ouvinte ouvinte = _context.Ouvintes.Find(id);

        if(ouvinte == null)
        {
            return NotFound();

        }

        return View (ouvinte);
    }

    public IActionResult Atualizar([FromForm] Ouvinte ouvinte){
        if (!ModelState.IsValid)
        {
            return View(ouvinte);
        }

    Ouvinte? ouvinteEncontrado = _context.Ouvintes.Find(ouvinte.Id);

        if(ouvinteEncontrado == null)
        {
            return NotFound();
        }
        
        ouvinteEncontrado.Id = ouvinte.Id;
        ouvinteEncontrado.Nome = ouvinte.Nome;
        ouvinteEncontrado.QtdeMusicas = ouvinte.QtdeMusicas;

        _context.Ouvintes.Update(ouvinteEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

    public IActionResult Deletar(int id)
    {
        Ouvinte ouvinte = _context.Ouvintes.Find(id);

        if(ouvinte == null)
        {
            return NotFound();
        }
        _context.Ouvintes.Remove(ouvinte);
        _context.SaveChanges();

        return View();
    }

}
