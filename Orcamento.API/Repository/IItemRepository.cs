using System.Collections.Generic;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public interface IItemRepository : IRepository<Item>
    {
         PagedList<Item> GetItems(ItemParameters itemParameters);
         IEnumerable<Item> GetItemPorPreco();
    }
}