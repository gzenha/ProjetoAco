using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Orcamento.API.Context;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(AppDbContext contexto) : base(contexto)
        {

        }
        public PagedList<Cliente> GetClientes(ClienteParameters clienteParameters)
        {
    
            return PagedList<Cliente>.ToPagedList(Get().OrderBy(c => c.Nome),
            clienteParameters.PageNumber, clienteParameters.PageSize);

                //return Get()
            //.OrderBy(c => c.Nome)
            //.Skip((clienteParameters.PageNumber - 1) * clienteParameters.PageSize)
            //.Take(clienteParameters.PageSize)
            //.ToList();
        }

        public IEnumerable<Cliente> GetCliente()
        {
            return Get().Include( c => c.Nome);
        }
    }
}