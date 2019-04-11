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
    public class ProdColorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdColorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/ProdColor
        [HttpGet]
        public IActionResult GetpProductColor()
        {
            var pc = _unitOfWork.ProdColorRep.GetAllPColor();
            return Ok(pc);
        }

        // GET: api/ProdColor/5
        [HttpGet("{id}")]
        public IActionResult GetpProductColor(int id)
        {
            var ProdColor = _unitOfWork.ProdColorRep.FindById(id);

            if (ProdColor == null)
            {
                return NotFound();
            }

            return Ok(ProdColor);
        }

        //// PUT: api/ProdColor/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutpProductColor(int id, pProductColor pProductColor)
        //{
        //    if (id != pProductColor.ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(pProductColor).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!pProductColorExists(id))
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

        // POST: api/ProdColor
        [HttpPost]
        public IActionResult PostProductColor(ProductColorVM ProdColor)
        {
            _unitOfWork.ProdColorRep.Insert(ProdColor);
            

            return CreatedAtAction("GetpProductColor", new { id = ProdColor.ID }, ProdColor);
        }       
    }
}
