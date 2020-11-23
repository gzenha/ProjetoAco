using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Orcamento.API.Validations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.API.Models
{
    public class Item
    {
        public Item()
        {
            ListaItens = new Collection<ListaItem>();
        }
        [Key]
        public int Iditem {get; set;}
         [Required]
        [MaxLength(80)]
        public string Descricao {get; set;}
        [Required]
        [MaxLength(300)]
        [PrimeiraLetraMaiuscula]
        public string Flag {get; set;}
        [Required]
        [MaxLength(2)]
        public decimal valoritem {get; set;}
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        public ICollection<ListaItem> ListaItens { get; set; }
    }
}