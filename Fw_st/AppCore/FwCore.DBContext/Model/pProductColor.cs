using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pProductColor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ID { get; set; }

        public int ProductID { get; set; }       
        public int ColorID { get; set; }

        public Product products { get; set; }
        public pColor Color { get; set; }
    }
}
