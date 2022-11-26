namespace MOTOMAMI.Models;

public class Album
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public int QtdeMusicas {get; set;}

     public Album(){}

     public Album(int id, string nome, int qtdeMusicas)
     {
        Id = id;
        Nome = nome;
        QtdeMusicas = qtdeMusicas;
     }

}