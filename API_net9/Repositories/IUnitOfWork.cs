namespace API_net9.Repositories
{
    public interface IUnitOfWork
    {
        //Através dessas interfaces é que vamos ter as intancias dos repositorio
        IProdutoRepository ProdutoRepository { get; }
        ICategoriaRepository CategoriaRepository { get;}
        void Commit();
    }
}
