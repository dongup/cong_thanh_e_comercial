using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.Products.ProductCatergory;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplateController : BaseApiController
    {
        public TemplateController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra danh sách danh mục kèm theo các template của danh mục đó
        /// </summary>
        /// <param name="keyword">Từ khóa tìm theo danh mục sản phẩm hoặc tên template</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.Templates)
                    .ThenInclude(x => x.PropertyTemplates)
                    .ThenInclude(x => x.Property).ThenInclude(x => x.Values)
                    .Where(delegate (CategoryEntity x)
                    {
                        return x.CategoryName.Like(keyword)
                        || x.Templates.Any(x => x.PropertyTemplateName.Like(keyword)) || string.IsNullOrEmpty(keyword);
                    })
                    .Select(x => new DetailCategoryResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Tìm template theo tên
        /// </summary>
        /// <param name="keyword">Từ khóa tìm theo danh mục sản phẩm</param>
        /// <returns></returns>
        [HttpGet("ByName")]
        public ResponseModel ByName(string keyword = "")
        {
            try
            {
                var result = _context.Templates
                    .Include(x => x.PropertyTemplates)
                    .ThenInclude(x => x.Property)
                    .Where(delegate (TemplateEntity x)
                    {
                        return x.PropertyTemplateName.Like(keyword);
                    })
                    .Select(x => new TemplateResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Lấy template theo danh mục sản phẩm
        /// </summary>
        /// <param name="id">Mã danh mục</param>
        /// <returns></returns>
        [HttpGet("ByCategoryId/{id}")]
        public ResponseModel ByCategoryId(int id)
        {
            try
            {
                var result = _context.Categories
                    .Include(x => x.Templates)
                    .ThenInclude(x => x.PropertyTemplates)
                    .ThenInclude(x => x.Property.Values)
                    .Where(x => x.Id == id)
                    .Select(x => new DetailCategoryResponse(x))
                    .ToList();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Lấy template nhiều danh mục
        /// </summary>
        /// <param name="ids">Dạng 1,2 </param>
        /// <returns></returns>
        [HttpGet("ByMutiCategoryIds/{ids}")]
        public ResponseModel ByCategoryId(string ids)
        {
            var arr = ids.Split(",");
            try
            {
               
                var result = _context.Templates
                   .Include(x => x.PropertyTemplates)
                   .Where(x=>arr.Contains(x.ProductCategory.Id.ToString()))
                   .Select(x => new TemplateResponse(x))
                   .ToList();
                res.Succeed(result);
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
                var result = _context.Templates
                    .Include(x => x.ProductCategory)
                    .Include(x => x.PropertyTemplates)
                    .Include(x => x.PropertyTemplates).ThenInclude(x => x.Property).ThenInclude(x => x.Values)
                    .Where(x => x.Id == id)
                    .Select(x => new TemplateResponse(x))
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
        public ResponseModel Post([FromBody] TemplateRequest value)
        {
            try
            {
                if (EntityExists(value.PropertyTemplateName))
                {
                    throw new Exception("Tên mẫu thuộc tính này đã được sử dụng, bạn vui lòng chọn tên khác!");
                }

                var entity = value.CopyTo(new TemplateEntity());
                entity.CreatedUserId = UserId;

                _context.Templates.Add(entity);
                _context.SaveChanges();

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] TemplateRequest value)
        {
            try
            {
                if (EntityExists(value.PropertyTemplateName, id))
                {
                    throw new Exception("Tên mẫu thuộc tính này đã được sử dụng, bạn vui lòng chọn tên khác!");
                }

                TemplateEntity entity = _context.Templates
                .Include(x => x.PropertyTemplates)
                .Where(x => x.Id == id)
                .FirstOrDefault();

                value.CopyTo(entity);

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
                    res.Result = ex.StackTrace;
                }
            }

            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Templates.Find(id);

                _context.Templates.Remove(entity);
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
            return _context.Templates.Any(x => x.PropertyTemplateName == name && (x.Id != id || id == 0));
        }

        private bool EntityExists(int id)
        {
            return _context.Templates.Any(x => x.Id == id);
        }
    }
}
