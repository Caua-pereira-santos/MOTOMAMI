namespace MOTOMAMI.Models;

public class Evento
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public string Lugar {get; set;}

     public Evento(){}

     public Evento(int id, string nome, string lugar)
     {
        Id = id;
        Nome = nome;
        Lugar = lugar;
     }

}