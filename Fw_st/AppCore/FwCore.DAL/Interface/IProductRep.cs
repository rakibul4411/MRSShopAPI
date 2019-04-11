using DTO;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DAL.Interface
{
    public interface IProductRep : IRepository<Product>
    {
        ProductVM FindById(int id);
        IEnumerable<ProductVM> GetAllProd();
        void Insert(ProductVM pvm);
        void Update(ProductVM pvm, int id);
        //void Delete(int cId);
    }
}
