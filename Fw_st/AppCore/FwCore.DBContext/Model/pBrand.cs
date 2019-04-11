using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pBrand
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; }       
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }

        public virtual Category categories { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
