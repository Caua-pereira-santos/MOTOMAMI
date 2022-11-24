namespace MOTOMAMI.Models;

public class Albuns
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public int Qtde {get; set;}

     public Albuns(){}

     public Albuns(int id, string nome, int qtde)
     {
        Id = id;
        Nome = nome;
        Qtde = qtde;
     }

}