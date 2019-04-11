using DTO;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DAL.Interface
{
    public interface IBrandRep : IRepository<pBrand>
    {
        BrandVM FindById(int id);
        IEnumerable<BrandVM> GetAllBrand();
        void Insert(BrandVM bvm);
        void Update(BrandVM bvm, int id);
        void Delete(int bId);
    }
}
