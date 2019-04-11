using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ID { get; set; }

        [ForeignKey("OrderID")]
        public int OrderID { get; set; }


        public int UserId { get; set; }


        //public virtual AppUser AppUser { get; set; }

        public virtual pOrder Order { get; set; }
    }
}
