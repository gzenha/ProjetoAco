using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Orcamento.API.Context;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        public ItemRepository(AppDbContext contexto): base(contexto)
        {
            
        }
        public PagedList<Item> GetItems(ItemParameters itemParameters)
        {
          //return Get()
          //.OrderBy(on => on.Descricao)
          //.Skip((itemParameters.PageNumber -1) * itemParameters.PageSize)
          //.Take(itemParameters.PageSize)
          //.ToList(); 

          return PagedList<Item>.ToPagedList(Get().OrderBy(i => i.Descricao),
          itemParameters.PageNumber, itemParameters.PageSize);
       }
        public IEnumerable<Item> GetItemPorPreco()
        {
            return Get().OrderBy(i => i.valoritem).ToList(); 
        }
    }
}