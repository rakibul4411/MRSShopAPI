using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FwCore.DBContext.Model
{
    public class ProductExtraInfo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Key]
        public int PInfoID { get; set; }
        public string RAM { get; set; }
        public string ROM { get; set; }
        public string StoreCapacity { get; set; }
        public string NumberOFSIM { get; set; }
        public string ProcessorType { get; set; }
        public string OperatingSystem { get; set; }
        public string FCamera { get; set; }
        public string BCamera { get; set; }
        public string Display { get; set; }
        public string CPUSpeed { get; set; }
        public string GraphicCard { get; set; }
        public string TvResulation { get; set; }
        public string Battery { get; set; }
        public string PowerBankCapacity { get; set; }
        public string HeadPhonFeature { get; set; }
        public string PortableSpeakerFeature { get; set; }
        public string AirCapacity { get; set; }
        public string PrintSpeed { get; set; }
        public string PenConnectorType { get; set; }
        public string Other { get; set; }

        [ForeignKey("ProductID")]
        public int? ProductID { get; set; }

        public virtual Product Product { get; set; }
    }
}
