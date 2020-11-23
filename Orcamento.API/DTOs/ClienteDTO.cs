using System.Collections.Generic;
using Orcamento.API.Models;

namespace Orcamento.API.DTOs
{
    public class ClienteDTO
    {
        public  int IdCliente  {get; set;}
        public string Nome {get; set;}
        public string Endereco {get; set;}
        public ICollection<Tborcamento> tborcamentos {get; set;}
    }
}