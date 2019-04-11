using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pUnitPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ID { get; set; }
        [Required]
        public decimal MarketPrice { get; set; }
        [Required]
        public decimal SellingPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime InsertdDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        
        public string UserId { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }


      
        public virtual Product Product { get; set; }
        //[ForeignKey("Id")]
        //public virtual AppUser appUser { get; set; }
    }
}
