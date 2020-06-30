using System;

namespace Excel
{
    class Program
    {
        static void Main(string[] args)
        {
            Produto p = new Produto();
            p.Codigo = 18125;
            p.Nome = "Impressora HP";
            p.Preco = 987.88f;

            p.Inserir(p);
        }
    }
}
