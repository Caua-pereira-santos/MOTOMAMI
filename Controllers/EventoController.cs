using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class EventoController : Controller
{
    private readonly MOTOMAMIContext _context;

    public EventoController(MOTOMAMIContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Eventos);
    }

    public IActionResult Cadastro()
    {
        return View();
    }

    public IActionResult Salvar([FromForm] Evento evento)
    {
        if(!ModelState.IsValid)
        {
            return View(evento);
        }

        _context.Eventos.Add(evento);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id)
    {
        Evento evento = _context.Eventos.Find(id);

        if(evento == null)
        {
            return NotFound();
        }

        return View(evento);
    }

    public IActionResult Editar(int id)
    {
        Evento evento = _context.Eventos.Find(id);

        if(evento == null)
        {
            return NotFound();
        }

        return View (evento);

    }

    public IActionResult Atualizar([FromForm] Evento evento)
    {
        if (!ModelState.IsValid)
        {
            return View(evento);
        }

        Evento? eventoEncontrado = _context.Eventos.Find(evento.Id);

        if(eventoEncontrado == null)
        {
            return NotFound();
        }

        eventoEncontrado.Id = evento.Id;
        eventoEncontrado.Nome = evento.Nome;
        eventoEncontrado.Lugar = evento.Lugar;

        _context.Eventos.Update(eventoEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Deletar(int id)
    {
        Evento evento = _context.Eventos.Find(id);

        if(evento == null)
        {
            return NotFound();
        }

        _context.Eventos.Remove(evento);
        _context.SaveChanges();

        return View();
    }
}