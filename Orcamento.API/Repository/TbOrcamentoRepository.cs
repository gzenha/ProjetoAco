using System.Collections.Generic;
using System.Linq;
using Orcamento.API.Context;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public class TbOrcamentoRepository : Repository<Tborcamento>, ITbOrcamentoRepository
    {
        public TbOrcamentoRepository(AppDbContext contexto) : base(contexto)
        {
            
        }

        public PagedList<Tborcamento> GetTborcamentos(TbOrcamentoParameters tbOrcamentoParameters)
        {
            return PagedList<Tborcamento>.ToPagedList(Get().OrderBy(o => o.sit_orcamento),
            tbOrcamentoParameters.PageNumber, tbOrcamentoParameters.PageSize);
            //return Get()
            //.OrderBy(o => o.sit_orcamento)
            //.Skip((tbOrcamentoParameters.PageNumber - 1) * tbOrcamentoParameters.PageSize)
            //.Take(tbOrcamentoParameters.PageSize)
            //.ToList();      
        }

        public IEnumerable<Tborcamento> GetTbOrcamentoPorPreco()
        {
            return Get().OrderBy(o => o.valor_total).ToList(); 
        }
    }
}