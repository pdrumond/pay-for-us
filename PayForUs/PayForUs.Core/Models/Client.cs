using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayForUs.Core.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ClientId { get; set; }

        [Required(ErrorMessage = "Nome é um campo obrigatório *")]
        public string Name { get; set; }

        [Required(ErrorMessage ="CPF é um campo obrigatório *")]
        [StringLength(11, ErrorMessage ="Limite máximo de 11 caracteres")]
        public string Cpf { get; set; }
        public Double LimitCredit { get; set; }
    }
}
