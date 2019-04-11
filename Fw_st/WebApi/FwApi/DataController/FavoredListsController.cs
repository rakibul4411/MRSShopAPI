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
    public class FavoredListsController : ControllerBase
    {
        private IUnitOfWork db;
        public FavoredListsController(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var wishList = db.FavoredList.GetAll();
            return Ok(wishList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var wishlistitem = db.FavoredList.Get(id);
            return Ok(wishlistitem);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            db.FavoredList.Remove(await db.FavoredList.Get(id));
            await db.CompleteAsync();
            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> PostCreate(FavListVM vm)
        {
            if (ModelState.IsValid)
            {

                db.FavoredList.Add(new CustFavoredList { FavoredListID = vm.FavoredListID, ProductID = vm.ProductID, UserId = vm.UserId});
                await db.CompleteAsync();
            }
            else
            {
                return BadRequest();
            }
            return Ok(vm);
        }
        [HttpPut("{id}")]
        public IActionResult PutUpdate(FavListVM vm, int id)
        {
            if (ModelState.IsValid)
            {
                var oldwishlist = db.FavoredList.Get(id).Result;
                if (oldwishlist != null)
                {
                    oldwishlist.FavoredListID = vm.FavoredListID;
                    oldwishlist.ProductID = vm.ProductID;
                    oldwishlist.UserId = oldwishlist.UserId;
                    db.CompleteAsync();
                }
                else
                {
                    return Content("This value not exits.");
                }
            }
            else
            {
                return BadRequest();
            }
            return Ok(vm);
        }
    }
}
