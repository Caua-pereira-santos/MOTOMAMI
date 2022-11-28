namespace MOTOMAMI.Models;

public class Ouvinte
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public string MusicaPreferida {get; set;}

     public Ouvinte(){}

     public Ouvinte(int id, string nome, string MusicaPreferida)
     {
        Id = id;
        Nome = nome;
        MusicaPreferida = musicaPreferida; // model para ouvinte
     }

}