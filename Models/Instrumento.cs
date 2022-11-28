namespace MOTOMAMI.Models;

public class Instrumento
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public string Classificacao {get; set;}

     public Instrumento(){}

     public Instrumento(int id, string nome, string classificacao)
     {
        Id = id;
        Nome = nome;
        Classificacao = classificacao;
     }

}