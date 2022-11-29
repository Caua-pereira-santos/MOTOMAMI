namespace MOTOMAMI.Models;

public class Ouvinte
{
     public int Id { get; set; }
     public string Nome{get; set;}
     public string Preferencia{get; set;}

     public Ouvinte(){}

     public Ouvinte(int id, string nome, string preferencia)
     {
        Id = id;
        Nome = nome;
        Preferencia = preferencia;
     }

}