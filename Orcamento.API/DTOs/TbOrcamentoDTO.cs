using System;
using System.Collections.Generic;
using Orcamento.API.Models;

namespace Orcamento.API.DTOs
{
    public class TbOrcamentoDTO
    {

       public int idorcamento {get; set;}
        public DateTime dt_orcamento {get; set;}
        public DateTime dt_alteracao {get; set;}
        public  string usu_orcamento {get; set;}
        public string usu_alteracao {get; set;}
        public decimal valor_total {get; set;}
        public decimal valor_descont {get; set;}
        public int sit_orcamento {get; set;}
        public int IdCliente {get; set;}
        public ICollection<ListaItem> ListaItens { get; set; }
        
    }
}