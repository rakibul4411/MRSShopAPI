using DTO;
using FwCore.DAL.Interface;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FwCore.DAL
{
    public class ProductRepo : Repository<Product>, IProductRep
    {

        public ProductRepo(AppDataDbContext context) : base(context)
        {

        }

        public AppDataDbContext db
        {
            get { return _context as AppDataDbContext; }
        }
        public ProductVM FindById(int id)
        {
            ProductVM data = (from c in db.pCategory
                              join p in db.Product
                              on c.CategoryID equals p.CategoryID
                              join b in db.pBrand
                              on p.BrandID equals b.BrandID
                              join pi in db.ProductExtraInfo
                              on p.ProductID equals pi.ProductID
                              join ps in db.pStock
                              on pi.ProductID equals ps.ProductID
                              join up in db.pUnitPrice
                              on ps.ProductID equals up.ProductID                            
                              //join pc in db.pProductColor
                              //on up.ProductID equals pc.ProductID
                              //join color in db.pColor
                              //on pc.ColorID equals color.ColorID
                              //let colorName = string.Join(",", color.ColorName)
                              //where (color.ColorID == pc.ColorID)
                              select new ProductVM
                                           {
                                               ProductID = p.ProductID,
                                               ProductName = p.ProductName,
                                               Category = c.CatName,
                                               BrandName = b.BrandName,
                                               Description = p.Description,
                                               Feature = p.Feature,
                                               ReturnPolicy = p.ReturnPolicy,
                                               WarrentyPolicy = p.WarrentyPolicy,
                                               BarCode = p.BarCode,
                                               QRCode = p.QRCode,
                                               ManufactureDate = p.ManufactureDate,
                                               DisplayOrder = p.DisplayOrder,
                                               InsertdDate = p.InsertdDate,
                                               UpdatedDate = p.UpdatedDate,
                                               UserId = p.UserId,
                                               IsActive = p.IsActive,
                                               IsVisiable = p.IsVisiable,
                                               RAM = pi.RAM,
                                               ROM = pi.ROM,
                                               StoreCapacity = pi.StoreCapacity,
                                               NumberOFSIM = pi.NumberOFSIM,
                                               ProcessorType = pi.ProcessorType,
                                               OperatingSystem = pi.OperatingSystem,
                                               FCamera = pi.FCamera,
                                               BCamera = pi.BCamera,
                                               Display = pi.Display,
                                               CPUSpeed = pi.CPUSpeed,
                                               GraphicCard = pi.GraphicCard,
                                               TvResulation = pi.TvResulation,
                                               Battery = pi.Battery,
                                               PowerBankCapacity = pi.PowerBankCapacity,
                                               HeadPhonFeature = pi.HeadPhonFeature,
                                               PortableSpeakerFeature = pi.PortableSpeakerFeature,
                                               AirCapacity = pi.AirCapacity,
                                               PenConnectorType = pi.PenConnectorType,
                                               PrintSpeed = pi.PrintSpeed,
                                               Other = pi.Other,
                                             // ProductColor = new List<string> { colorName },
                                              tQuantity = ps.tQuantity,
                                              mlQuantity = ps.mlQuantity,
                                              tpQuantity = ps.tpQuantity,
                                              MarketPrice = up.MarketPrice,
                                              SellingPrice = up.SellingPrice
                              }).Where(i => i.ProductID == id).FirstOrDefault();

            return data;
        }

        public IEnumerable<ProductVM> GetAllProd()
        {
            IEnumerable<ProductVM> data = (from c in db.pCategory
                                           join p in db.Product
                                           on c.CategoryID equals p.CategoryID
                                           join b in db.pBrand
                                           on p.BrandID equals b.BrandID
                                           join pi in db.ProductExtraInfo
                                           on p.ProductID equals pi.ProductID
                                           join ps in db.pStock
                                           on pi.ProductID equals ps.ProductID
                                           join up in db.pUnitPrice
                                           on ps.ProductID equals up.ProductID
                                           //join pc in db.pProductColor
                                           //on up.ProductID equals pc.ProductID
                                           //join color in db.pColor
                                           //on pc.ColorID equals color.ColorID
                                           //orderby p.ProductID
                                           //let  colorName = string.Join(",", color.ColorName)
                                           //where(color.ColorID == pc.ColorID)
                                           orderby p.ProductName
                                           select new ProductVM
                                           {
                                               ProductID = p.ProductID,
                                               ProductName = p.ProductName,
                                               Category = c.CatName,
                                               BrandName = b.BrandName,
                                               Description = p.Description,
                                               Feature = p.Feature,
                                               ReturnPolicy = p.ReturnPolicy,
                                               WarrentyPolicy = p.WarrentyPolicy,
                                               BarCode = p.BarCode,
                                               QRCode = p.QRCode,
                                               ManufactureDate = p.ManufactureDate,
                                               DisplayOrder = p.DisplayOrder,
                                               InsertdDate = p.InsertdDate,
                                               UpdatedDate = p.UpdatedDate,
                                               UserId = p.UserId,
                                               IsActive = p.IsActive,
                                               IsVisiable = p.IsVisiable,
                                               RAM = pi.RAM,
                                               ROM = pi.ROM,
                                               StoreCapacity = pi.StoreCapacity,
                                               NumberOFSIM = pi.NumberOFSIM,
                                               ProcessorType = pi.ProcessorType,
                                               OperatingSystem = pi.OperatingSystem,
                                               FCamera = pi.FCamera,
                                               BCamera = pi.BCamera,
                                               Display = pi.Display,
                                               CPUSpeed = pi.CPUSpeed,
                                               GraphicCard = pi.GraphicCard,
                                               TvResulation = pi.TvResulation,
                                               Battery = pi.Battery,
                                               PowerBankCapacity = pi.PowerBankCapacity,
                                               HeadPhonFeature = pi.HeadPhonFeature,
                                               PortableSpeakerFeature = pi.PortableSpeakerFeature,
                                               AirCapacity = pi.AirCapacity,
                                               PenConnectorType = pi.PenConnectorType,
                                               PrintSpeed = pi.PrintSpeed,
                                               Other = pi.Other,
                                               //ProductColor = new List<string> { colorName },
                                               tQuantity = ps.tQuantity,
                                               mlQuantity = ps.mlQuantity,
                                               tpQuantity = ps.tpQuantity,
                                               MarketPrice = up.MarketPrice,
                                               SellingPrice = up.SellingPrice
                                             }).ToList();

            return data;
        }

        public void Insert(ProductVM pvm)
        {
            Product product = new Product();
            product.ProductID = pvm.ProductID;
            product.ProductName = pvm.ProductName;
            product.Description = pvm.Description;
            product.Feature = pvm.Feature;
            product.ReturnPolicy = pvm.ReturnPolicy;
            product.WarrentyPolicy = pvm.WarrentyPolicy;
            product.BarCode = pvm.BarCode;
            product.QRCode = pvm.QRCode;
            product.ManufactureDate = pvm.ManufactureDate;
            product.DisplayOrder = pvm.DisplayOrder;
            product.InsertdDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            product.UserId = pvm.UserId;
            product.IsActive = pvm.IsActive;
            product.IsVisiable = pvm.IsVisiable;
            db.Product.Add(product);
            db.SaveChanges();
            int lastProductId = product.ProductID;
            string lastUserId = product.UserId;

            //ProductExtraInfo Entity
            ProductExtraInfo pxi = new ProductExtraInfo();
            pxi.PInfoID = pvm.PInfoID;
            pxi.RAM = pvm.RAM;
            pxi.ROM = pvm.ROM;
            pxi.StoreCapacity = pvm.StoreCapacity;
            pxi.NumberOFSIM = pvm.NumberOFSIM;
            pxi.ProcessorType = pvm.ProcessorType;
            pxi.OperatingSystem = pvm.OperatingSystem;
            pxi.FCamera = pvm.FCamera;
            pxi.BCamera = pvm.BCamera;
            pxi.Display = pvm.Display;
            pxi.CPUSpeed = pvm.CPUSpeed;
            pxi.GraphicCard = pvm.GraphicCard;
            pxi.TvResulation = pvm.TvResulation;
            pxi.Battery = pvm.Battery;
            pxi.PowerBankCapacity = pvm.PowerBankCapacity;
            pxi.HeadPhonFeature = pvm.HeadPhonFeature;
            pxi.PortableSpeakerFeature = pvm.PortableSpeakerFeature;
            pxi.AirCapacity = pvm.AirCapacity;
            pxi.PenConnectorType = pvm.PenConnectorType;
            pxi.PrintSpeed = pvm.PrintSpeed;
            pxi.Other = pvm.Other;

            //Insert ForeignKey Value
            pxi.ProductID = lastProductId;
            db.ProductExtraInfo.Add(pxi);
            db.SaveChanges();

            ///ProducColor Entity
            //pProductColor pc = new pProductColor();
            //pc.ColorID = pvm.ColorID;
            //pc.ProductID = lastProductId;
            //db.pProductColor.Add(pc);
            //db.SaveChanges();

            //Product stock Entity
            pStock ps = new pStock();
            ps.StockID = pvm.StockID;
            ps.tQuantity = pvm.tQuantity;
            ps.mlQuantity = pvm.mlQuantity;
            ps.InsertdDate = DateTime.Now;
            ps.UpdatedDate = DateTime.Now;
            ps.ProductID = lastProductId;
            ps.UserId = lastUserId;
            db.pStock.Add(ps);
            db.SaveChanges();

            ///Product Unit price Entity
            pUnitPrice pup = new pUnitPrice();
            pup.ID = pvm.ID;
            pup.MarketPrice = pvm.MarketPrice;
            pup.SellingPrice = pvm.SellingPrice;
            pup.InsertdDate = pvm.InsertdDate;
            pup.UpdatedDate = pvm.UpdatedDate;
            pup.UserId = lastUserId;
            pup.ProductID = lastProductId;
            db.SaveChanges();
        }

        public void Update(ProductVM pvm, int id)
        {
            Product product = new Product();
            product.ProductID = pvm.ProductID;
            product.ProductName = pvm.ProductName;
            product.Description = pvm.Description;
            product.Feature = pvm.Feature;
            product.ReturnPolicy = pvm.ReturnPolicy;
            product.WarrentyPolicy = pvm.WarrentyPolicy;
            product.BarCode = pvm.BarCode;
            product.QRCode = pvm.QRCode;
            product.ManufactureDate = pvm.ManufactureDate;
            product.DisplayOrder = pvm.DisplayOrder;
            product.InsertdDate = DateTime.Now;
            product.UpdatedDate = DateTime.Now;
            product.UserId = pvm.UserId;
            product.IsActive = pvm.IsActive;
            product.IsVisiable = pvm.IsVisiable;
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
            int lastProductId = product.ProductID;
            string lastUserId = product.UserId;

            //ProductExtraInfo Entity
            ProductExtraInfo pxi = new ProductExtraInfo();
            pxi.PInfoID = pvm.PInfoID;
            pxi.RAM = pvm.RAM;
            pxi.ROM = pvm.ROM;
            pxi.StoreCapacity = pvm.StoreCapacity;
            pxi.NumberOFSIM = pvm.NumberOFSIM;
            pxi.ProcessorType = pvm.ProcessorType;
            pxi.OperatingSystem = pvm.OperatingSystem;
            pxi.FCamera = pvm.FCamera;
            pxi.BCamera = pvm.BCamera;
            pxi.Display = pvm.Display;
            pxi.CPUSpeed = pvm.CPUSpeed;
            pxi.GraphicCard = pvm.GraphicCard;
            pxi.TvResulation = pvm.TvResulation;
            pxi.Battery = pvm.Battery;
            pxi.PowerBankCapacity = pvm.PowerBankCapacity;
            pxi.HeadPhonFeature = pvm.HeadPhonFeature;
            pxi.PortableSpeakerFeature = pvm.PortableSpeakerFeature;
            pxi.AirCapacity = pvm.AirCapacity;
            pxi.PenConnectorType = pvm.PenConnectorType;
            pxi.PrintSpeed = pvm.PrintSpeed;
            pxi.Other = pvm.Other;

            //Insert ForeignKey Value
            pxi.ProductID = lastProductId;
            db.Entry(pxi).State = EntityState.Modified; ;
            db.SaveChanges();

            ///ProducColor Entity
            //pProductColor pc = new pProductColor();
            //pc.ColorID = pvm.ColorID;
            //pc.ProductID = lastProductId;
            //db.pProductColor.Add(pc);
            //db.SaveChanges();

            //Product stock Entity
            pStock ps = new pStock();
            ps.StockID = pvm.StockID;
            ps.tQuantity = pvm.tQuantity;
            ps.mlQuantity = pvm.mlQuantity;
            ps.InsertdDate = DateTime.Now;
            ps.UpdatedDate = DateTime.Now;
            ps.ProductID = lastProductId;
            ps.UserId = lastUserId;
            db.Entry(ps).State = EntityState.Modified;
            db.SaveChanges();

            ///Product Unit price Entity
            pUnitPrice pup = new pUnitPrice();
            pup.ID = pvm.ID;
            pup.MarketPrice = pvm.MarketPrice;
            pup.SellingPrice = pvm.SellingPrice;
            pup.InsertdDate = pvm.InsertdDate;
            pup.UpdatedDate = pvm.UpdatedDate;
            pup.UserId = lastUserId;
            pup.ProductID = lastProductId;
            db.Entry(pup).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
