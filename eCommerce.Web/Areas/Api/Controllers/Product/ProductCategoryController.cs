using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.General;
using eCommerce.Web.Entities.Product;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : BaseApiController
    {
        public ProductCategoryController(DatabaseContext context, UserManager<UserEntity> userManager = null) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra các danh mục kem cac thuoc tinh filter
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetFilter")]
        public ResponseModel GetFilter()
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Values)
                    .Select(x => new CategoryFilterResponse(x))
                    .ToList();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy ra các thuộc tính bộ lọc theo danh mục
        /// </summary>
        /// <returns></returns>
        [HttpGet("CategoryFilter/{id}")]
        public ResponseModel GetFilterByCategoryId(int id)
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Values)
                    .Where(x => x.Id == id)
                    .Select(x => new CategoryFilterResponse(x))
                    .FirstOrDefault();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy ra các danh mục chưa có nhóm
        /// </summary>
        /// <returns></returns>
        [HttpGet("NoGroupCategory")]
        public ResponseModel NoGroupCategory()
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.CategoryGroup)
                    .Include(x => x.ProductCategories)
                    .Where(x => x.CategoryGroup == null)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new CategoryResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.ProductCategories)
                    .Include(x => x.Properties)
                    .Where(delegate (CategoryEntity x)
                    {
                        return x.CategoryName.Like(keyword);
                    })
                    .OrderBy(x => x.CategoryName)
                    .Select(x => new CategoryResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpGet("GetByMutilId/{ids}")]
        public ResponseModel GetByMutilId(string ids)
        {
            try
            {
                var arr = ids.Split(",");
                var result = _context.Categories
                    .Include(x => x.ProductCategories)
                    .Where(x => arr.Contains(x.Id.ToString()))
                    .OrderBy(x => x.CategoryName)
                    .Select(x => new CategoryResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.Properties)
                    .ThenInclude(x => x.Values)
                    .Where(x => x.Id == id)
                    .Select(x => new CategoryResponse(x))
                    .FirstOrDefault();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPost]
        public ResponseModel Post([FromBody] CategoryRequest value)
        {
            try
            {
                if (EntityExists(value.CategoryName))
                {
                    res.Failed("Tên danh mục đã được sử dụng bạn vui lòng chọn tên khác!");
                    return res;
                }
                var entity = value.CopyTo(new CategoryEntity());
                entity.CreatedUserId = UserId;

                //AddUrl(UrlType.ProductCategory, value.FriendlyUrl);

                _context.Categories.Add(entity);
                _context.SaveChanges();

                res.Succeed(new CategoryResponse(entity));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] CategoryRequest value)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                if (_context.Categories.Where(n => n.CategoryName == value.CategoryName && n.Id != id).FirstOrDefault() != null)
                {
                    res.Failed("Tên danh mục đã được sử dụng bạn vui lòng chọn tên khác!");
                    return res;
                }

                var entity = _context.Categories.Where(n => n.Id == id).FirstOrDefault();

                //UpdateUrl(entity.FriendlyUrl, value.FriendlyUrl, UrlType.ProductCategory);

                value.CopyTo(entity);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                _context.SaveChanges();

                res.Succeed(new CategoryResponse(entity));
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
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
                var entity = _context.Categories.Find(id);
                _context.Categories.Remove(entity);

                DeleteUrl(entity.FriendlyUrl);

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
            return _context.Categories.Any(x => x.CategoryName == name && (x.Id != id || id == 0));
        }

        private bool EntityExists(int id)
        {
            return _context.Categories.Any(x => x.Id == id);
        }
    }
}
