using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Purchase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int UserId { get; set; } 

        [ForeignKey("UserId")]
        public Client CLient { get; set; }  

        public decimal TotalAmount { get; set; }

        public ICollection<SaleLine> SaleLine { get; set; }
    }
}
