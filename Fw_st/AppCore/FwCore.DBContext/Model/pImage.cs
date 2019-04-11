using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class pImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int ImageID { get; set; }
        public string Caption { get; set; }
        public string FilePathOrLink { get; set; }
        public string ThumbnailPathOrLink { get; set; }
        public string ShortDetails { get; set; }
        public bool IsDefault { get; set; }

        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
