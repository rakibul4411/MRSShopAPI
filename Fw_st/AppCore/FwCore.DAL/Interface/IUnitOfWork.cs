using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRep CategoryRep { get; }
        IBrandRep BrandRep { get; }
        IProductRep ProductRep { get; }
        IOrderRep OrderRep { get; }
        IProdColorRep ProdColorRep { get;}
        Repository<CustFavoredList> FavoredList { get; }

        Task<bool> CompleteAsync();
    }
}
