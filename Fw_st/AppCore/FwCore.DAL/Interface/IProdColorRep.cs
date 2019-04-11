using DTO;
using FwCore.DAL.Interface;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DAL
{
    public interface IProdColorRep : IRepository<pProductColor>
    {
        List<ProductColorVM> FindById(int id);
        IEnumerable<ProductColorVM> GetAllPColor();
        void Insert(ProductColorVM pcvm);
        void Update(ProductColorVM pcvm, int id);
        void Delete(int bId);
    }
}
