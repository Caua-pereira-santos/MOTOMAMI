namespace MOTOMAMI.Models;

public class Gravadora
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public string Genero {get; set;}

     public Gravadora(){}

     public Gravadora(int id, string nome, string genero)
     {
        Id = id;
        Nome = nome;
        Genero = genero;
     }

}