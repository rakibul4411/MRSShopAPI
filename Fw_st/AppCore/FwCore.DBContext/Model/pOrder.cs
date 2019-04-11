using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int OrderID { get; set; }

        [DataType(DataType.Date)]
        public DateTime OrderPlaceDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DelevaryDate { get; set; }


        public bool IsPaid { get; set; }
        public bool IsDelevered { get; set; }

        public string UserId { get; set; }
        //[ForeignKey("OSAID")]
        //public int? OSAID { get; set; }

       public virtual oShipingAddress ShipingAddress { get; set; }
       public virtual Payment Payment { get; set; }

    }
}
