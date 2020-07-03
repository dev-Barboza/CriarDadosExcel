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

            Produto Alterado = new Produto();
            Alterado.Codigo = 3;
            Alterado.Nome = "Ventilador";
            Alterado.Preco = 500f;
            
            
            p.Alterar(Alterado);

            

            List<Produto> lista = new List<Produto>();
            lista = p.Ler();

         

            foreach(Produto item in lista )
            {
               
                System.Console.WriteLine($"R$ {item.Preco} . {item.Nome}");
            }
        }
    }
}
