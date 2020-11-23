using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Orcamento.API.Models
{
    public class ListaItem
    {   
        [Key]
        public int idlistaitem {get; set;}
         [Required]
        [MaxLength(80)]

        public decimal valor {get; set;}
        public Tborcamento orcamento {get; set;}
        public int idorcamento {get; set;}
        public Item item {get; set;}
        public int iditem {get; set;}
       
    }
}