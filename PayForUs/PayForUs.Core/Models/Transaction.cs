using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PayForUs.Core.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid TransactionId { get; set; }
        public Double Amount { get; set; }
        public Guid CardId { get; set; }
        public int Number { get; set; }
        public int StatusId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }


        public Card Card { get; set; }

    }
}
