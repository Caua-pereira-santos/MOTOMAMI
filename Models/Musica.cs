namespace MOTOMAMI.Models;

public class Musica
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public int Duracao{get; set;}

     public Musica(){}

     public Musica(int id, string nome, int duracao)
     {
        Id = id;
        Nome = nome;
        Duracao = duracao;
     }

}