using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

public class Produto
    {
        
        public int Codigo {get;set;}
        public string Nome {get;set;}
        public float Preco {get;set;}

        private const string PATH = "Database/Produto.csv";

        /// <summary>
        /// criar pasta caso nao exista
        /// </summary>
        public Produto()
        {

            
            string pasta = PATH.Split('/')[0]; 

            if(!Directory.Exists(pasta))
            {
                Directory.CreateDirectory(pasta);
            }


            if(!File.Exists(PATH))
            {
                File.Create(PATH).Close();
            }
        
        }


        /// <summary>
        /// Inserir produto em csv
        /// </summary>
        /// <param name="p"></param>
        public void Inserir(Produto p){
            var linha = new string [] {p.PrepararLinhaCSV(p)};
            File.AppendAllLines(PATH, linha);
        }

        /// <summary>
        /// ira ler os produtos listados, criar array de linha, separar as linhas em split
        /// </summary>
        /// <returns></returns>
        public List<Produto> Ler()
        {
            //criar a lista para return

            List<Produto> produtos = new List<Produto>();
            
            //arry de linhas 
            string[] linhas = File.ReadAllLines(PATH);

            //separar cada linha com split
            foreach(string linha in linhas)
            {
            string[] dado = linha.Split(";");

            //criar instancia para add na lista

            Produto x = new Produto();
            
            x.Codigo = Int32.Parse(separar(dado[0]));
            x.Nome = separar(dado[1]);
            x.Preco = float.Parse(separar(dado[2]));
            
            produtos.Add(x);
            }

            produtos = produtos.OrderBy(y=> y.Nome).ToList();
            
            return produtos;
        }

        /// <summary>
        /// Ira remover determinada linha 
        /// </summary>
        /// <param name="_termo"></param>
        public void Remover(string _termo)
        {
            //Lista de backup

            List<string> linhas = new List<string>();

            // usado para ler csv
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha= arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(l => l.Contains(_termo));

            
            ReescreverCSV(linhas);


            // forma de reescerever os dados

            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string li in linhas)
                {
                    output.Write(li + "\n");
                }
            }

            
            

        }


        public void Alterar(Produto produtoAlterado)
        {
                 List<string> linhas = new List<string>();

            // usado para ler csv
            using(StreamReader arquivo = new StreamReader(PATH))
            {
                string linha;
                while((linha= arquivo.ReadLine()) != null)
                {
                    linhas.Add(linha);
                }
            }

            linhas.RemoveAll(x => x.Split(";")[0].Contains(produtoAlterado.Codigo.ToString()));
            Codigo.ToString();

            linhas.Add(PrepararLinhaCSV(produtoAlterado));

            ReescreverCSV(linhas);
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string li in linhas)
                {
                    output.Write(li + "\n");
                }
            }
        }

         private void ReescreverCSV(List<string> lines){
            
            using(StreamWriter output = new StreamWriter(PATH))
            {
                foreach(string ln in lines)
                {
                    output.Write(ln + "\n");
                }
            }   
        }




        public List<Produto> Filtrar(string _nome)
        {
            return Ler().FindAll(x => x.Nome == _nome);
        }
       
        //CRIADO PARA OTIMIZAR O TEMPO 
       /// <summary>
       /// criado para otimizar o tempo na hora de instanciar
       /// </summary>
       /// <param name="_coluna"></param>
       /// <returns></returns>
        
        /// <summary>
        /// Separar as linhas da tabela com o "="
        /// </summary>
        /// <param name="_coluna"></param>
        /// <returns></returns>
        private string separar(string _coluna)
        {
            return _coluna.Split("=")[1];
        }

        /// <summary>
        /// Organizar a linha de forma correta 
        /// </summary>
        /// <param name="produto"></param>
        /// <returns></returns>
        private string PrepararLinhaCSV(Produto produto){

            return $"Cod= {produto.Codigo}; Nome = {produto.Nome}; Preco = {produto.Preco}";
        }
    }
