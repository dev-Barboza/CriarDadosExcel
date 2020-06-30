using System;
using System.Collections.Generic;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            p.Codigo = 1812;
            p.Nome = "Microondas lg ";
            p.Preco = 5600f;

            p.Inserir(p);

            List<Produto> Lista  = p.Ler();

            foreach(Produto item in Lista )
            {
               
                System.Console.WriteLine($"R$ {item.Preco} . {item.Nome}");
            }
        }
    }
}
