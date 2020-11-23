using System.Collections.Generic;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public interface IListaItemRepository : IRepository<ListaItem>
    
    {
         PagedList<ListaItem> GetListaItems(ListaItemParameters listaItemParameters);
         IEnumerable<ListaItem> GetListaItem();
    }
}