using FwCore.DAL.Interface;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FwCore.DAL
{
   public class UnitOfWork : IUnitOfWork
    {
        private AppDataDbContext db;
        private ICategoryRep _categoryRep;
        private IBrandRep _brandRep;
        private IProductRep _productRep;
        private IOrderRep _orderRep;
        private IProdColorRep _prodColorRep;
        private Repository<CustFavoredList> _FavoredList;

        public UnitOfWork(AppDataDbContext context)
        {
            this.db = context;
        }

        public ICategoryRep CategoryRep => _categoryRep ?? (_categoryRep = new CategoryRepo(db));
        public IBrandRep BrandRep => _brandRep ?? (_brandRep = new BrandRepo(db));
        public IProductRep ProductRep => _productRep ?? (_productRep = new ProductRepo(db));
        public IOrderRep OrderRep => _orderRep ?? (_orderRep = new OrderRepo(db));
        public IProdColorRep ProdColorRep => _prodColorRep ?? (_prodColorRep = new ProductColorRepo(db));
        public Repository<CustFavoredList> FavoredList
        {
            get
            {
                if (this._FavoredList == null)
                {
                    this._FavoredList = new Repository<CustFavoredList>(db);
                }
                return _FavoredList;
            }
        }

        public async Task<bool> CompleteAsync()
        {
            return await db.SaveChangesAsync() > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
