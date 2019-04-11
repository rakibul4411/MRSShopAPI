using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pOrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int OrderDetailsID { get; set; }

        public int UnitQuantity { get; set; }
        public double perUnitSellingPrice { get; set; }
        //public double TotalBill { get; set; }
        //public double NetBill { get; set; }

        [ForeignKey("OrderID")]
        public int? OrderID { get; set; }
        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }

        public virtual pOrder Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
