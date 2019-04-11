using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Feature { get; set; }
        public string ReturnPolicy { get; set; }
        public string WarrentyPolicy { get; set; }
        public string BarCode { get; set; }
        public string QRCode { get; set; }
        public DateTime ManufactureDate { get; set; }
        [Required]
        public int DisplayOrder { get; set; }
        [DataType(DataType.Date)]
        public DateTime InsertdDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }

       // [ForeignKey("Id")]
        public string UserId { get; set; }

        public bool IsActive { get; set; }
        public bool IsVisiable { get; set; }
        [ForeignKey("CategoryID")]
        public int? CategoryID { get; set; }
        [ForeignKey("BrandID")]
        public int? BrandID { get; set; }



        public virtual ICollection<pProductColor> ProductColor { get; set; }
        public virtual pOrderDetails OrderDetail { get; set; }
        public virtual pBrand Brand { get; set; }
        public virtual Category Categories { get; set; }
        public virtual ProductExtraInfo ProductExtraInfo { get; set; }
        public virtual pStock Stock { get; set; }
        public virtual pUnitPrice UnitPrice { get; set; }
        public virtual ICollection<pImage> Image { get; set; }
        
    }
}
  