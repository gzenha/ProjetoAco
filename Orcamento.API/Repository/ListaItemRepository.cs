using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Orcamento.API.Context;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public class ListaItemRepository : Repository<ListaItem>, IListaItemRepository
    {
        public ListaItemRepository(AppDbContext contexto) : base (contexto)
        {
            
        }

        public PagedList<ListaItem> GetListaItems(ListaItemParameters listaItemParameters)
        {
            //return Get()
            //.OrderBy(l => l.idlistaitem)
            //.Skip((listaItemParameters.PageNumber -1) * listaItemParameters.PageSize)
            //.Take(listaItemParameters.PageSize)
            //.ToList();
        return PagedList<ListaItem>.ToPagedList(Get().OrderBy(l => l.idlistaitem), 
        listaItemParameters.PageNumber, listaItemParameters.PageSize);

        }
        public IEnumerable<ListaItem> GetListaItem()
        {
            return Get().Include(l => l.valor);
        }
    }
}