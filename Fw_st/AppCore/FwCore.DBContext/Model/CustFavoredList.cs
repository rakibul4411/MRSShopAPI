using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FwCore.DBContext.Model
{
    public class CustFavoredList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int FavoredListID { get; set; }

        [ForeignKey("ProductID")]
        public int ProductID { get; set; }

        public int UserId { get; set; }

        public virtual Product Product { get; set; }
    }
}
