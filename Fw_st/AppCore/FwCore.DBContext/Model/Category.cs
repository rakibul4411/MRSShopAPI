using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string CatName { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        [DataType(DataType.Date)]
        public DateTime InsseredDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisiable { get; set; }
        [ForeignKey("CategoryID")]
        public int? ParentCatID { get; set; }


        public virtual ICollection<Category> categories { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
