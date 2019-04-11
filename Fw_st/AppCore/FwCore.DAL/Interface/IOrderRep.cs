using DTO;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace FwCore.DAL.Interface
{
    public interface IOrderRep : IRepository<pOrder>
    {
        OrderVM FindById(int id);
        IEnumerable<OrderVM> GetAllOrder();
        void Insert(OrderVM ovm);
        void Update(OrderVM ovm, int id);
        void Delete(int Id);
    }
}
