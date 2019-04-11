using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using FwCore.DAL.Interface;
using DTO;

namespace FwApi.DataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrderController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Order
        [HttpGet]
        public IActionResult GetpOrder()
        {
            var data = _unitOfWork.OrderRep.GetAllOrder();
            return Ok(data);
        }

        // GET: api/Order/5
        [HttpGet("{id}")]
        public IActionResult GetpOrder(int id)
        {
            var data = _unitOfWork.OrderRep.FindById(id);
            return Ok(data);
        }

        // PUT: api/Order/5
        [HttpPut("{id}")]
        public IActionResult PutpOrder(OrderVM Order, int id)
        {
            _unitOfWork.OrderRep.Update(Order, id);
            return Ok("Update successful");
        }

        // POST: api/Order
        [HttpPost]
        public IActionResult PostpOrder(OrderVM order)
        {
            _unitOfWork.OrderRep.Insert(order);

            return CreatedAtAction("GetpOrder", new { id = order.OrderID }, order);
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public IActionResult DeletepOrder(int id)
        {
            _unitOfWork.OrderRep.Delete(id);
            return Ok("Delete successful");
        }
    }
}
