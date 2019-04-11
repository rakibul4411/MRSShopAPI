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
    public class BrandController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cat
        [HttpGet]
        public IActionResult GetpBrand()
        {
            var brands = _unitOfWork.BrandRep.GetAllBrand().ToList();
            return Ok(brands);
        }

        // GET: api/Cat/5
        [HttpGet("{id}")]
        public IActionResult GetBrand(int id)
        {
            var brands = _unitOfWork.BrandRep.FindById(id);

            if (brands == null)
            {
                return NotFound();
            }

            return Ok(brands);
        }

        // PUT: api/Cat/5
        [HttpPut("{id}")]
        public IActionResult PutBrand(int id, BrandVM brands)
        {
            if (id != brands.BrandID)
            {
                return BadRequest();
            }

            _unitOfWork.BrandRep.Update(brands, id);

            return Ok();
        }

        // POST: api/Cat
        [HttpPost]
        public IActionResult PostBrand([FromBody] BrandVM brands)
        {
            _unitOfWork.BrandRep.Insert(brands);

            return CreatedAtAction("GetCategory", new { id = brands.BrandID }, brands);
        }

        // DELETE: api/Cat/5
        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            _unitOfWork.BrandRep.Delete(id);

            return Ok();
        }
    }
}
