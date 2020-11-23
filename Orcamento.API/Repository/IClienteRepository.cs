using System.Collections.Generic;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        PagedList<Cliente> GetClientes(ClienteParameters clienteParameters);
        IEnumerable<Cliente> GetCliente();     
    }
}