using DTO;
using FwCore.DAL.Interface;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FwCore.DAL
{
    public class OrderRepo : Repository<pOrder>, IOrderRep
    {
        public OrderRepo(AppDataDbContext context) : base(context)
        {

        }

        public AppDataDbContext db
        {
            get { return _context as AppDataDbContext; }
        }

        public void Delete(int Id)
        {
           var data =  db.pOrder.Find(Id);
            db.pOrder.Remove(data);
            db.SaveChanges();
        }

        public OrderVM FindById(int id)
        {
            OrderVM data = (from o in db.pOrder
                                         join od in db.pOrderDetails
                                         on o.OrderID equals od.OrderID
                                         join sa in db.oShipingAddress
                                         on o.OrderID equals sa.OrderID
                                         join pay in db.Payment
                                         on o.OrderID equals pay.OrderID
                                         join paytye in db.paymentType
                                         on pay.PaymentTypeID equals paytye.PaymentTypeID
                                         orderby o.OrderPlaceDate
                                         select new OrderVM
                                         {
                                             OrderID = o.OrderID,
                                             OrderPlaceDate = o.OrderPlaceDate,
                                             DelevaryDate = o.OrderPlaceDate,
                                             IsDelevered = o.IsDelevered,
                                             IsPaid = o.IsPaid,
                                             UserId = o.UserId,
                                             OrderDetailsID = od.OrderDetailsID,
                                             ProductID = od.ProductID,
                                             UnitQuantity = od.UnitQuantity,
                                             perUnitSellingPrice = od.perUnitSellingPrice,
                                             OSAID = sa.OSAID,
                                             AddressLine1 = sa.AddressLine1,
                                             State = sa.State,
                                             City = sa.City,
                                             Country = sa.Country,
                                             PostalCode = sa.PostalCode,
                                             PaymentID = pay.PaymentID,
                                             TransID = pay.TransID,
                                             Amount = pay.Amount,
                                             PaymentTypeID = pay.PaymentTypeID
                                         }).Where(i => i.OrderID == id).FirstOrDefault();

            return data;
        }

        public IEnumerable<OrderVM> GetAllOrder()
        {
            IEnumerable<OrderVM> data = (from o in db.pOrder
                                         join od in db.pOrderDetails
                                         on o.OrderID equals od.OrderID
                                         join sa in db.oShipingAddress
                                         on o.OrderID equals sa.OrderID
                                         join pay in db.Payment
                                         on o.OrderID equals pay.OrderID
                                         join paytye in db.paymentType
                                         on pay.PaymentTypeID equals paytye.PaymentTypeID
                                         orderby o.OrderPlaceDate
                                         select new OrderVM
                                         {
                                            OrderID = o.OrderID,
                                            OrderPlaceDate = o.OrderPlaceDate,
                                            DelevaryDate = o.OrderPlaceDate,
                                            IsDelevered = o.IsDelevered,
                                            IsPaid = o.IsPaid,
                                            UserId = o.UserId,
                                            OrderDetailsID = od.OrderDetailsID,
                                            ProductID = od.ProductID,
                                            UnitQuantity = od.UnitQuantity,
                                            perUnitSellingPrice = od.perUnitSellingPrice,
                                            OSAID = sa.OSAID,
                                            AddressLine1 = sa.AddressLine1,
                                            State = sa.State,
                                            City = sa.City,
                                            Country = sa.Country,
                                            PostalCode = sa.PostalCode,
                                            PaymentID = pay.PaymentID,
                                            TransID = pay.TransID,
                                            Amount = pay.Amount,
                                            PaymentTypeID = pay.PaymentTypeID
                                         }).ToList();

            return data;
        }

        public void Insert(OrderVM ovm)
        {
            ////Order table Insert Data
            pOrder order = new pOrder();
            order.OrderID = ovm.OrderID;
            order.OrderPlaceDate = DateTime.Now;
            order.DelevaryDate = DateTime.Now.AddDays(2);
            order.IsDelevered = ovm.IsDelevered;
            order.IsPaid = ovm.IsPaid;
            order.UserId = ovm.UserId;
            db.pOrder.Add(order);
            db.SaveChangesAsync();
            var lastOrderId = order.OrderID;

            ////Order Details table Insert Data

            pOrderDetails pod = new pOrderDetails();
            pod.OrderDetailsID = ovm.OrderDetailsID;
            pod.ProductID = ovm.ProductID;
            pod.UnitQuantity = ovm.UnitQuantity;
            pod.perUnitSellingPrice = ovm.perUnitSellingPrice;
            pod.OrderID = lastOrderId;
            db.pOrderDetails.Add(pod);
            db.SaveChangesAsync();

            /////Shiping address table Insert data

            oShipingAddress sp = new oShipingAddress();
            sp.OSAID = ovm.OSAID;
            sp.AddressLine1 = ovm.AddressLine1;
            sp.State = ovm.State;
            sp.City = ovm.City;
            sp.Country = ovm.Country;
            sp.PostalCode = ovm.PostalCode;
            sp.OrderID = lastOrderId;
            db.oShipingAddress.Add(sp);
            db.SaveChangesAsync();

            ////Payment table Insert Data
            ///
            Payment pay = new Payment();
            pay.PaymentID = ovm.PaymentID;
            pay.TransID = ovm.TransID;
            pay.Amount = ovm.Amount;
            pay.OrderID = ovm.OrderID;
            pay.PaymentTypeID = ovm.PaymentTypeID;
            db.Payment.Add(pay);
            db.SaveChangesAsync();
        }

        public void Update(OrderVM ovm, int id)
        {
            ////Order table Insert Data
            pOrder order = new pOrder();
            order.OrderID = ovm.OrderID;
            order.OrderPlaceDate = DateTime.Now;
            order.DelevaryDate = DateTime.Now.AddDays(2);
            order.IsDelevered = ovm.IsDelevered;
            order.IsPaid = ovm.IsPaid;
            order.UserId = ovm.UserId;
            db.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChangesAsync();
            var lastOrderId = order.OrderID;

            ////Order Details table Insert Data

            pOrderDetails pod = new pOrderDetails();
            pod.OrderDetailsID = ovm.OrderDetailsID;
            pod.ProductID = ovm.ProductID;
            pod.UnitQuantity = ovm.UnitQuantity;
            pod.perUnitSellingPrice = ovm.perUnitSellingPrice;
            pod.OrderID = lastOrderId;
            db.Entry(pod).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChangesAsync();

            /////Shiping address table Insert data

            oShipingAddress sp = new oShipingAddress();
            sp.OSAID = ovm.OSAID;
            sp.AddressLine1 = ovm.AddressLine1;
            sp.State = ovm.State;
            sp.City = ovm.City;
            sp.Country = ovm.Country;
            sp.PostalCode = ovm.PostalCode;
            sp.OrderID = lastOrderId;
            db.Entry(sp).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChangesAsync();

            ////Payment table Insert Data
            ///
            Payment pay = new Payment();
            pay.PaymentID = ovm.PaymentID;
            pay.TransID = ovm.TransID;
            pay.Amount = ovm.Amount;
            pay.OrderID = ovm.OrderID;
            pay.PaymentTypeID = ovm.PaymentTypeID;
            db.Entry(pay).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChangesAsync();
        }
    }
}
