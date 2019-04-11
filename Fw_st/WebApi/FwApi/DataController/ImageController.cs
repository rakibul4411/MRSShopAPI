using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FwCore.DBContext;
using FwCore.DBContext.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FwApi.DataController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly AppDataDbContext _context;
        private IHostingEnvironment henv;

        public ImageController(AppDataDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            henv = hostingEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> PostImage(IFormFile file, string caption, bool isDefault, int pId)
        {
            if (file == null || file.Length == 0) return Content("File not selected");

            string path_root = henv.WebRootPath;
            string path_to_Image = path_root + "\\Upload\\" + file.FileName;

            using (var stream = new FileStream(path_to_Image, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            pImage im = new pImage();
            //im.ImageID = ivm.ImageID;
            im.FilePathOrLink = path_to_Image;
            im.ShortDetails = file.FileName;
            im.Caption = caption;
            //im.IsDefault = isDefault;
            //im.ProductID = pId;
            _context.Images.Add(im);
            _context.SaveChanges();

            return Ok("Upload image successful");
        }

        public IActionResult GetImage(int id , int pId)
        {
            var data = from i in _context.Images
                       where i.ImageID == id && i.ProductID == pId
                       select i;
            return Ok(data);
        } 
    }
}