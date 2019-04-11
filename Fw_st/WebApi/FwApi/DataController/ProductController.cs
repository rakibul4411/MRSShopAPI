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
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Product
        [HttpGet]
        public IActionResult GetProduct()
        {
            var prod = _unitOfWork.ProductRep.GetAllProd();
            return Ok(prod);
        }

        // GET: api/Product/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product =_unitOfWork.ProductRep.FindById(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        //// PUT: api/Product/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutProduct(int id, Product product)
        //{
        //    if (id != product.ProductID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(product).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Product
        [HttpPost]
        public IActionResult PostProduct(ProductVM product)
        {
            _unitOfWork.ProductRep.Insert(product);

            return CreatedAtAction("GetProduct", new { id = product.ProductID }, product);
        }

        //// DELETE: api/Product/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Product>> DeleteProduct(int id)
        //{
        //    var product = await _context.Product.FindAsync(id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Product.Remove(product);
        //    await _context.SaveChangesAsync();

        //    return product;
        //}

        //private bool ProductExists(int id)
        //{
        //    return _context.Product.Any(e => e.ProductID == id);
        //}
    }
}
