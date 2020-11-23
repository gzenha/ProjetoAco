namespace Orcamento.API.Repository
{
    public interface IUnitOfWork
    {
         IClienteRepository ClienteRepository { get; }
         IItemRepository ItemRepository { get;} 

         IListaItemRepository ListaItemRepository { get; }

         ITbOrcamentoRepository TbOrcamentoRepository { get; }

         void Commit();
         
    }
}