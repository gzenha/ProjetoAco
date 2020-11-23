using Orcamento.API.Context;

namespace Orcamento.API.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ClienteRepository _clienteRepo;
        private ItemRepository _itemRepo;
        private ListaItemRepository _listaitemRepo;
        private TbOrcamentoRepository _tborcamentoRepo;
        public AppDbContext _context;

        public UnitOfWork(AppDbContext contexto)
        {
            _context = contexto;
        }
        public IClienteRepository ClienteRepository 
        {
            get
            {
                return _clienteRepo = _clienteRepo ?? new ClienteRepository(_context);
            }
        }
        public IItemRepository ItemRepository
         {
             get
             {
                 return _itemRepo = _itemRepo ?? new ItemRepository(_context);
             }
         }

        public IListaItemRepository ListaItemRepository 
        {
            get
            {
                return _listaitemRepo = _listaitemRepo ?? new ListaItemRepository(_context);
            }

        }

        public ITbOrcamentoRepository TbOrcamentoRepository 
        {
            get
            {
                return _tborcamentoRepo = _tborcamentoRepo ?? new TbOrcamentoRepository (_context);
            }

        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}