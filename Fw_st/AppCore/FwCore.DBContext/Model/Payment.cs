using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class Payment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int PaymentID { get; set; }
        public string TransID { get; set; }
        public double Amount { get; set; }

        [ForeignKey("OrderID")]
        public int? OrderID { get; set; }

        [ForeignKey("PaymentTypeID")]
        public int? PaymentTypeID { get; set; }

        public virtual pOrder Order { get; set; }

        public virtual ICollection<PaymentType> PaymentType { get; set; }
    }
}
