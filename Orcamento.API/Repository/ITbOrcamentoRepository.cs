using System.Collections.Generic;
using Orcamento.API.Models;
using Orcamento.API.Pagination;

namespace Orcamento.API.Repository
{
    public interface ITbOrcamentoRepository : IRepository<Tborcamento>
    {
        PagedList<Tborcamento> GetTborcamentos(TbOrcamentoParameters tbOrcamentoParameters);
        IEnumerable<Tborcamento> GetTbOrcamentoPorPreco();

    }
}