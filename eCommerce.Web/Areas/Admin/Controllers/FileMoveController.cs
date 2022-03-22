using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    public class FileMoveController : BaseController
    {
        IWebHostEnvironment Env;
        public FileMoveController(DatabaseContext context, IWebHostEnvironment env) : base(context)
        {
            Env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult update(int Number)
        {
            string res = "";

            int i = 0;
            var products = _context.Products
                .Include(n => n.ProductCategories).ThenInclude(n => n.Category)
                .Include(n => n.ProductImages).ThenInclude(n => n.Image)
                .ToList();
            var path = Env.WebRootPath + @"\Upload\Products";
            var a = Env;
            foreach (var item in products)
            {
                string cateName = item.ProductCategories.FirstOrDefault().Category.CategoryName;
                var pathCate = path + @"\" + cateName;
                if (!Directory.Exists(pathCate))
                    Directory.CreateDirectory(pathCate);
                var pathProductname = pathCate + @"\" + item.FriendlyUrl;
                if (!Directory.Exists(pathProductname))
                {
                    if (i == Number) break;
                    i += 1;
                    res += item.Id + "__";
                    Directory.CreateDirectory(pathProductname);
                    foreach (var img in item.ProductImages)
                    {
                        var pathSource = pathProductname + @"\" + img.Image.FilePath.Split('/').LastOrDefault();
                        var pathSourceThumb = pathProductname + @"\" + img.Image.ThumbNailPath.Split('/').LastOrDefault();
                        var pathOld = Env.WebRootPath + @"\" + img.Image.FilePath.Replace(@"/", @"\");
                        var pathThumbOld = Env.WebRootPath + @"\" + img.Image.ThumbNailPath.Replace(@"/", @"\");
                        if (System.IO.File.Exists(pathOld))
                        {
                            var fileName = img.Image.FilePath.Split('/').LastOrDefault();
                            System.IO.File.Move(pathOld, pathSource);
                            img.Image.FilePath = @"Upload/Products/" + cateName.Replace(" ", "%20") + @"/" + item.FriendlyUrl + @"/" + fileName;
                        }
                        if (System.IO.File.Exists(pathThumbOld))
                        {
                            var fileName = img.Image.FilePath.Split('/').LastOrDefault();
                            System.IO.File.Move(pathThumbOld, pathSourceThumb);
                            img.Image.ThumbNailPath = @"Upload/Products/" + cateName.Replace(" ", "%20") + @"/" + item.FriendlyUrl + @"/" + fileName;
                        }
                        item.ThumbNail = img.Image.ThumbNailPath;
                        var count = _context.SaveChanges();
                    }
                }

            }
            return View("index", res);
        }
    }
}
