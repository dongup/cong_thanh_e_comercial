using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using eCommerce.Web.Areas.Api.Models.General;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductBrandController : BaseApiController
    {

        public ProductBrandController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager) { }



        /// <summary>
        /// Lấy danh sách các nhãn hiệu
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm</param>
        /// <param name="categoryIds">Danh sách các danh mục, định dạng: "1,2,3,4"</param>
        /// <param name="categoryUrl">Url danh mục</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel GetAll(string keyword, string categoryIds, string categoryUrl = "")
        {
            try
            {
                List<int> ctgryIds = new List<int>();
                if (!string.IsNullOrEmpty(categoryIds))
                {
                    ctgryIds = categoryIds.Split(",")
                        .Select(x => int.Parse(x))
                        .Where(x => x != 0)
                        .ToList();
                }

                var query = _context.ProductBrands
                    .Where(x =>
                        (x.BrandCategories.Any(x => ctgryIds.Contains(x.ProductCategoryId)) || ctgryIds.Count == 0)
                        && (x.BrandCategories.Any(x => x.ProductCategory.FriendlyUrl.Contains(categoryUrl)) || categoryUrl == "")
                    )
                    .OrderBy(n => n.Order).ThenBy(n => n.BrandName)
                   .Select(x => new ProductBrandResponse()
                   {
                       Id = x.Id,
                       LogoId = x.LogoId,
                       BrandName = x.BrandName,
                       Categories = x.BrandCategories.Select(n => new CategoryResponse()
                       {
                           CategoryName = n.ProductCategory.CategoryName,
                           Id = n.ProductCategory.Id
                       }).ToList(),
                       Logo = new FileResponse()
                       {
                           FileName = x.Logo.FileName,
                           FilePath = x.Logo.FilePath,
                           ThumbNailPath = x.Logo.ThumbNailPath,
                           Id = x.LogoId.GetValueOrDefault()
                       },
                       CountProduct = (int)x.Products.Count(),
                   })
                   .AsNoTracking()
                   .ToList();
                var result = query.Where(n => Global.CompareString(n.BrandName, keyword));
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            try
            {
                var result = _context.ProductBrands
                    .Include(x => x.Products)
                    .Include(x => x.Logo)
                    .Include(x => x.BrandCategories).ThenInclude(x => x.ProductCategory)
                    .Where(x => x.Id == id)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new ProductBrandResponse(x))
                    .FirstOrDefault();
                if (result == null) { throw NotFoundException; }

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] ProductBrandRequest value)
        {
            try
            {
                if (EntityExists(value.BrandName))
                {
                    throw new Exception("Tên nhãn hiệu nãy đã tồn tại, bạn vui lòng chọn tên khác!");
                }

                var entity = value.CopyTo(new ProductBrandEntity());
                entity.Note = value.Note;
                int.TryParse(value.Note, out int stt);
                entity.Order = stt == 0 ? 1000 : stt;
                entity.CreatedUserId = UserId;

                _context.ProductBrands.Add(entity);
                _context.SaveChanges();

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.InnerException.Message;
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] ProductBrandRequest value)
        {
            try
            {
                if (EntityExists(value.BrandName, id))
                {
                    throw new Exception("Tên nhãn hiệu nãy đã tồn tại, bạn vui lòng chọn tên khác!");
                }

                var entity = _context.ProductBrands
                                    .Include(x => x.BrandCategories)
                                    .FirstOrDefault(x => x.Id == id);

                value.CopyTo(entity);
                int.TryParse(value.Note, out int stt);
                entity.Note = value.Note;
                entity.Order = stt == 0 ? 1000 : stt;
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                _context.SaveChanges();

                res.Succeed();
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                }
            }

            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.ProductBrands.Find(id);
                _context.ProductBrands.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                if (!EntityExists(id))
                {
                    res.NotFound();
                }
                else
                {
                    res.Failed(ex.Message);
                }
            }

            return res;
        }

        private bool EntityExists(string name, int id = 0)
        {
            return _context.ProductBrands.Any(x => x.BrandName == name && (x.Id != id || id == 0));
        }

        private bool EntityExists(int id)
        {
            return _context.ProductBrands.Any(x => x.Id == id);
        }
    }
}
