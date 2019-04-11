using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class BrandVM
    {
        [Required]
        public int BrandID { get; set; }
        [Required]
        public string BrandName { get; set; }
    }
}
