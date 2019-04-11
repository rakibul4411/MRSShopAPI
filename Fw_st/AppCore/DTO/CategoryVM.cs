using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
   public class CategoryVM
    {
        public int CategoryID { get; set; }
        [Required]
        public string CatName { get; set; }

        public int DisplayOrder { get; set; }
        [DataType(DataType.Date)]
        public DateTime InsseredDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVisiable { get; set; }

        public int? ParentCatID { get; set; }
        public string ParentCatName{ get; set; }
    }
}
