using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace xtrade.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [EmailAddress]
        public string Seller { get; set; }

        [EmailAddress]
        public string Buyer { get; set; }

        [Required]
        public double amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set;  }

        [StringLength(500)]
        public string Description { get; set; }






    }
}