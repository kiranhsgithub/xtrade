using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Web;

namespace xtrade.Models
{
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }

        [StringLength(255)]
        public string ImageName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }   
        
        [Required]
        public double Amount { get; set; }     


        public int? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public virtual ICollection<BargainRecord> BargainRecords { get; set; }
    }
}