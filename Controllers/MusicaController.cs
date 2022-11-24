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

    public IActionResult Detalhes(int id)
    {
        Musica musica = _context.Musicas.Find(id);

        if(musica == null)
        {
            return NotFound();
        }

        return View(musica);
    }

    public IActionResult Editar(int id){
        Musica musica = _context.Musicas.Find(id);

        if(musica == null)
        {
            return NotFound();
        }

        return View(musica);
    }
    public IActionResult Atualizar([FromForm] Musica musica){
        if (!ModelState.IsValid)
        {
            return View(musica);
        }

    Musica? musicaEncontrada = _context.Musicas.Find(musica.Id);

        if(musicaEncontrada == null)
        {
            return NotFound();
        }
        
        musicaEncontrada.Id = musica.Id;
        musicaEncontrada.Nome = musica.Nome;
        musicaEncontrada.Duracao = musica.Duracao;

        _context.Musicas.Update(musicaEncontrada);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

    public IActionResult Deletar(int id)
    {
        Musica musica = _context.Musicas.Find(id);

        if(musica == null)
        {
            return NotFound();
        }
         _context.Musicas.Remove(musica);
        _context.SaveChanges();

        return View();
        
    }
}

