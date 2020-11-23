using System.Collections.Generic;
using Orcamento.API.Models;

namespace Orcamento.API.DTOs
{
    public class ItemDTO
    {
        public int Iditem {get; set;}
        public string Descricao {get; set;}
        public string Flag {get; set;}

        public decimal valoritem {get; set;}
        public ICollection<ListaItem> ListaItens { get; set; }
    }
}