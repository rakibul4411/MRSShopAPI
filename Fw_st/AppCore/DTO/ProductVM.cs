using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
    public class ProductVM
    {
        // Product table Info
        public int ProductID { get; set; }

        public string ProductName { get; set; }
        public string Description { get; set; }
        public string Feature { get; set; }
        public string ReturnPolicy { get; set; }
        public string WarrentyPolicy { get; set; }
        public string BarCode { get; set; }
        public string QRCode { get; set; }
        public DateTime ManufactureDate { get; set; }
        public int DisplayOrder { get; set; }
        [DataType(DataType.Date)]
        public DateTime InsertdDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime UpdatedDate { get; set; }
        public string UserId { get; set; }

        public bool IsActive { get; set; }
        public bool IsVisiable { get; set; }

       
        public int CategoryID { get; set; }
        public string Category{ get; set; }
        public int BrandID { get; set; }
        public string BrandName { get; set; }
        // Product Extra information table info

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
        //public int ProductID { get; set; }

        ///ProductColor
        //public int ProductID { get; set; }
        public int ColorID { get; set; }
        public List<string> ProductColor { get; set; }

        // product stock information

        public int StockID { get; set; }
        public int tQuantity { get; set; }
        public int tpQuantity { get; set; }
        public int mlQuantity { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime InsertdDate { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime UpdatedDate { get; set; }

        //[ForeignKey("Id")]
        //public string UserId { get; set; }
        //[ForeignKey("ProductID")]
        //public int? ProductID { get; set; }

        //Product Unite Price Information

        public int ID { get; set; }
        public decimal MarketPrice { get; set; }
        public decimal SellingPrice { get; set; }

        //[DataType(DataType.Date)]
        //public DateTime InsertdDate { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime UpdatedDate { get; set; }


        //public string UserId { get; set; }

        //[ForeignKey("ProductID")]
        //public int ProductID { get; set; }

        ///Product Image Information
        ///
        //public int ImageID { get; set; }
        //public string Caption { get; set; }
        //public string FilePathOrLink { get; set; }
        //public string ThumbnailPathOrLink { get; set; }
        //public string ShortDetails { get; set; }
        //public bool IsDefault { get; set; }

        //[ForeignKey("ProductID")]
        //public int? ProductID { get; set; }
    }
}
