using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayForUs.Core.Models
{
    public class Card
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CardId { get; set; }
        public string CardholderName { get; set; }
        public string Cpf { get; set; }

        [Required]
        public string NumberCard { get; set; }

        [Required]
        public string ExpirationDate { get; set; }

        [Required]
        public string CardBrand { get; set; }
        public string Password { get; set; }

        [Required]
        public string Type { get; set; }
        public bool HasPassword { get; set; }
        public DateTime CreatedBy { get; set; }
         
        public ICollection<Transaction> Transaction { get; set; }

        

    }
}
