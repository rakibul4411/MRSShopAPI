using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pReview
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ReviewID { get; set; }

        public double Rating { get; set; }
        public double AveRating { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }

       // [ForeignKey("Id")]
        public string UserId { get; set; }


        //public virtual AppUser AppUser { get; set; }
        public virtual Product Product { get; set; }
    }
}
