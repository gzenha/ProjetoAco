using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Orcamento.API.Validations;

namespace Orcamento.API.Models
{
    public class Cliente

    {   

        public Cliente ()
        {
            tborcamentos = new Collection<Tborcamento>();
        }

        public static object TotalCount { get; internal set; }
        [Key]
        public  int IdCliente  {get; set;}
        public string Nome {get; set;}
        [Required]
        [MaxLength(80)]
        [PrimeiraLetraMaiuscula]
        public string Endereco {get; set;}
        [Required]
        [MaxLength(300)]
        [PrimeiraLetraMaiuscula]

        public ICollection<Tborcamento> tborcamentos {get; set;}
    }
}