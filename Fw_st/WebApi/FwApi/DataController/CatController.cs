using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using FwCore.DAL;
using DTO;
using FwCore.DAL.Interface;

namespace FwApi.DataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CatController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cat
        [HttpGet]
        public IActionResult GetpCategory()
        {
            var cat = _unitOfWork.CategoryRep.GetAllCat().ToList();
            return Ok(cat);
        }

        // GET: api/Cat/5
        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _unitOfWork.CategoryRep.FindById(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        // PUT: api/Cat/5
        [HttpPut("{id}")]
        public IActionResult PutCategory(int id, CategoryVM category)
        {
            if (id != category.CategoryID)
            {
                return BadRequest();
            }

            _unitOfWork.CategoryRep.Update(category, id);

            return Ok();
        }

        // POST: api/Cat
        [HttpPost]
        public IActionResult PostCategory([FromBody] CategoryVM category)
        {
            _unitOfWork.CategoryRep.Insert(category);

            return CreatedAtAction("GetCategory", new { id = category.CategoryID }, category);
        }

        // DELETE: api/Cat/5
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {          
            _unitOfWork.CategoryRep.Delete(id);

            return Ok();
        }
    }
}
