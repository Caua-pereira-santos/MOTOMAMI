using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class GravadoraController : Controller
{
    private readonly MOTOMAMIContext _context;

    public GravadoraController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Gravadoras);
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Salvar([FromForm] Gravadora gravadora)
    {
        if(!ModelState.IsValid)
        {
            return View(gravadora);
        }

        _context.Gravadoras.Add(gravadora);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        Gravadora gravadora = _context.Gravadoras.Find(id);

        if(gravadora == null)
        {
            return NotFound();
        }

        return View (gravadora);
    }

   public IActionResult Editar(int id)
   {
    Gravadora gravadora = _context.Gravadoras.Find(id);

    if(gravadora == null)
    {
        return NotFound();
    }

    return View (gravadora);

   }

   public IActionResult Atualizar([FromForm] Gravadora gravadora){
        if (!ModelState.IsValid)
        {
            return View(gravadora);
        }

    Gravadora? gravadoraEncontrada = _context.Gravadoras.Find(gravadora.Id);

        if(gravadoraEncontrada == null)
        {
            return NotFound();
        }
        
        gravadoraEncontrada.Id = gravadora.Id;
        gravadoraEncontrada.Nome = gravadora.Nome;
        gravadoraEncontrada.Genero = gravadora.Genero;

        _context.Gravadoras.Update(gravadoraEncontrada);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

   public IActionResult Deletar(int id)
   {
    
    Gravadora gravadora = _context.Gravadoras.Find(id);

    if(gravadora == null)
    {
        return NotFound();
    }

    _context.Gravadoras.Remove(gravadora);
    _context.SaveChanges();

    return View();
   }
}