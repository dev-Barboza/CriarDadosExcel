namespace Excel
{
    public interface IProduto
    {
         void Inserir(Produto produto);
         void listar();

         void Remover(Produto produto);

         void Alterar(Produto produto);
    }
}