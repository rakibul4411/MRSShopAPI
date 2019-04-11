using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FwCore.DBContext.Model
{
    public class pStock
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int StockID { get; set; }
        [Required]
        public int tQuantity { get; set; }
        [Required]
        public int tpQuantity { get; set; }
        [Required]
        public int mlQuantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime InsertdDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

        //[ForeignKey("Id")]
        public string UserId { get; set; }

        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }


        
        public virtual Product Product { get; set; }
       // public AppUser appUser { get; set; }
    }
}
