using DTO;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DAL.Interface
{
    public interface ICategoryRep : IRepository<Category>
    {  
        CategoryVM FindById(int? id);
        IEnumerable<CategoryVM> GetAllCat();
        void Insert(CategoryVM cvm);
        void Update(CategoryVM cvm, int id);
        void Delete(int cId);
    }
}
