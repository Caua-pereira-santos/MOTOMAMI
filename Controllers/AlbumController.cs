using Microsoft.AspNetCore.Mvc;
using MOTOMAMI.Models;

namespace MOTOMAMI.Controllers;

public class AlbumController : Controller
{
    private readonly MOTOMAMIContext _context;

    public AlbumController(MOTOMAMIContext context)
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

    public IActionResult Salvar([FromForm] Album album)
    {
        if(!ModelState.IsValid)
        {
            return View(album); //Criar ums view de salvar albuns, pois a utilizada atualmente é a de músicas
        }

        _context.Albuns.Add(album);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Detalhes(int id) //View utilizada atualmente é a de música
    {
        Album album = _context.Albuns.Find(id);

        if(album == null)
        {
            return NotFound();
        }

        return View(album);
    }

    public IActionResult Editar(int id) //View utilizada atualmente é a de música
    {
        Album album = _context.Albuns.Find(id);

        if(album == null)
        {
            return NotFound();

        }

        return View (album);
    }

    public IActionResult Atualizar([FromForm] Album album){
        if (!ModelState.IsValid)
        {
            return View(album);
        }

    Album? albumEncontrado = _context.Albuns.Find(album.Id);

        if(albumEncontrado == null)
        {
            return NotFound();
        }
        
        albumEncontrado.Id = album.Id;
        albumEncontrado.Nome = album.Nome;
        albumEncontrado.QtdeMusicas = album.QtdeMusicas;

        _context.Albuns.Update(albumEncontrado);
        _context.SaveChanges();
        return RedirectToAction("Index");

    }

    public IActionResult Deletar(int id)
    {
        Album album = _context.Albuns.Find(id);

        if(album == null)
        {
            return NotFound();
        }
        _context.Albuns.Remove(album);
        _context.SaveChanges();

        return View();
    }

}