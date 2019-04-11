using DTO;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FwCore.DAL
{
    public class ProductColorRepo : Repository<pProductColor>, IProdColorRep
    {
        public ProductColorRepo(AppDataDbContext context) : base(context)
        {
        }

        public AppDataDbContext db
        {
            get { return _context as AppDataDbContext; }
        }

        public void Delete(int bId)
        {
            throw new NotImplementedException();
        }

        public List<ProductColorVM> FindById(int id)
        {
            List<ProductColorVM> pc = (from p in db.Product
                                 join proCol in db.pProductColor
                                 on p.ProductID equals proCol.ProductID
                                 join c in db.pColor
                                 on proCol.ColorID equals c.ColorID
                                 select new ProductColorVM
                                 {
                                     ID = proCol.ID,
                                     ProductID = p.ProductID,
                                     ProductName = p.ProductName,
                                     Color = c.ColorName
                                 }).Where(i => i.ProductID == id).ToList();
            return pc;
        }

        public IEnumerable<ProductColorVM> GetAllPColor()
        {
            IEnumerable<ProductColorVM> pc = (from p in db.Product
                                              join proCol in db.pProductColor
                                              on p.ProductID equals proCol.ProductID
                                              join c in db.pColor
                                              on proCol.ColorID equals c.ColorID
                                              select new ProductColorVM
                                              {
                                                  ID = proCol.ID,
                                                  ProductID = p.ProductID,
                                                  ProductName = p.ProductName,
                                                  Color = c.ColorName
                                              }).ToList();
            return pc;
        }

        public void Insert(ProductColorVM pcvm)
        {
            pProductColor pc = new pProductColor();
            pc.ID = pcvm.ID;
            pc.ProductID = pcvm.ProductID;
            pc.ColorID = pcvm.ColorID;
            db.pProductColor.Add(pc);
            db.SaveChanges();
        }

        public void Update(ProductColorVM pcvm, int id)
        {
            throw new NotImplementedException();
        }
    }
}
