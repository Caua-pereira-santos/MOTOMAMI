using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class InstrumentoController : Controller
{
    private readonly MOTOMAMIContext _context;

    public InstrumentoController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Instrumentos);
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Salvar([FromForm] Instrumento instrumento)
    {
        if(!ModelState.IsValid)
        {
            return View(instrumento);
        }

        _context.Instrumentos.Add(instrumento);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        Instrumento instrumento = _context.Instrumentos.Find(id);

        if(instrumento == null)
        {
            return NotFound();
        }

        return View (instrumento);
    }

   public IActionResult Editar(int id)
   {
    Instrumento instrumento = _context.Instrumentos.Find(id);

    if(instrumento == null)
    {
        return NotFound();
    }

    return View (instrumento);

   }

   public IActionResult Atualizar([FromForm] Instrumento instrumento){
        if (!ModelState.IsValid)
        {
            return View(instrumento);
        }

    Instrumento? instrumentoEncontrado = _context.Instrumentos.Find(instrumento.Id);

        if(instrumentoEncontrado == null)
        {
            return NotFound();
        }
        
        instrumentoEncontrado.Id = instrumento.Id;
        instrumentoEncontrado.Nome = instrumento.Nome;
        instrumentoEncontrado.Classificacao = instrumento.Classificacao;

        _context.Instrumentos.Update(instrumentoEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

   public IActionResult Deletar(int id)
   {
    
    Instrumento instrumento = _context.Instrumentos.Find(id);

    if(instrumento == null)
    {
        return NotFound();
    }

    _context.Instrumentos.Remove(instrumento);
    _context.SaveChanges();

    return View();
   }
}