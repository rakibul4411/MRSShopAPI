using DTO;
using FwCore.DAL.Interface;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FwCore.DAL
{
    public class BrandRepo : Repository<pBrand>, IBrandRep
    {
        public BrandRepo(AppDataDbContext context) : base(context)
        {
        }

        public AppDataDbContext db
        {
            get { return _context as AppDataDbContext; }
        }

        public void Delete(int bId)
        {
            pBrand br = db.pBrand.Find(bId);
            db.pBrand.Remove(br);
            db.SaveChanges();
        }

        public BrandVM FindById(int id)
        {
            BrandVM vm = (from b in db.pBrand
                         select new BrandVM
                         {
                             BrandID = b.BrandID,
                             BrandName = b.BrandName
                         }).Where(i => i.BrandID == id).FirstOrDefault();
            return vm;
        }

        public IEnumerable<BrandVM> GetAllBrand()
        {
            IEnumerable<BrandVM> vm = (from b in db.pBrand
                                       select new BrandVM
                                       {
                                           BrandID = b.BrandID,
                                           BrandName = b.BrandName
                                       }).ToList();
            return vm;
        }

        public void Insert(BrandVM bvm)
        {
            pBrand br = new pBrand();
            br.BrandID = bvm.BrandID;
            br.BrandName = bvm.BrandName;
            db.pBrand.Add(br);
            db.SaveChanges();
        }

        public void Update(BrandVM bvm, int id)
        {
            pBrand br = new pBrand();
            br.BrandID = bvm.BrandID;
            br.BrandName = bvm.BrandName;
            db.Entry(br).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
        }
    }
}
