using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Orcamento.API.Models
{
    public class Tborcamento
    {

        public Tborcamento()
        {
          ListaItens = new Collection<ListaItem>();   
        }
        
        [Key]
        public int idorcamento {get; set;}
         [Required]
        [MaxLength(80)]
        public DateTime dt_orcamento {get; set;}
        [Required]
   
        public DateTime dt_alteracao {get; set;}
        public  string usu_orcamento {get; set;}
        [Required]
     
        public string usu_alteracao {get; set;}
        public decimal valor_total {get; set;}
        [Required]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
       
        public decimal valor_descont {get; set;}
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(8,2)")]
        public int sit_orcamento {get; set;}
        [Required]

        public Cliente  cliente {get; set;}
        public int IdCliente {get; set;}

        public ICollection<ListaItem> ListaItens { get; set; }

    }
}