using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Products.ProductCatergory;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Product;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using eCommerce.Web.Areas.Api.Models;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryGroupController : BaseApiController
    {
        public ProductCategoryGroupController(DatabaseContext context, UserManager<UserEntity> userManager = null) : base(context, userManager: userManager)
        {

        }

        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.ProductCategoryGroups
                    .Include(x => x.Categories)
                    .OrderBy(x => x.GroupName)
                    .Where(delegate (ProductCategoryGroupEntity x)
                    {
                        return x.GroupName.Like(keyword);
                    })
                    .Select(x => new ProductCategoryGroupResponse(x))
                    .ToList();
                res.Succeed(result ?? new List<ProductCategoryGroupResponse>());
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
                var result = _context.ProductCategoryGroups
                    .Include(x => x.Categories)
                    .Where(x => x.Id == id)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new ProductCategoryGroupResponse(x))
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
        public ResponseModel Post([FromBody] ProductCategoryGroupRequest value)
        {
            try
            {
                if (EntityExists(value.GroupName))
                {
                    res.Failed("Tên nhóm danh mục đã được sử dụng bạn vui lòng chọn tên khác!");
                    return res;
                }

                var entity = value.CopyTo(new ProductCategoryGroupEntity());

                List<CategoryEntity> listorder = new List<CategoryEntity>();
                for (int i = 0; i < value.CategoryIds.Count; i++)
                {
                    var it = _context.Categories
                        .Where(x => x.Id == value.CategoryIds[i]).FirstOrDefault();
                    it.OrderLevel = i + 1;
                    listorder.Add(it);
                }
                entity.CreatedUserId = UserId;
                entity.Categories = listorder;

                _context.ProductCategoryGroups.Add(entity);
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
        public ResponseModel Put(int id, [FromBody] ProductCategoryGroupRequest value)
        {
            try
            {
                if (EntityExists(value.GroupName, id))
                {
                    res.Failed("Tên nhóm danh mục đã được sử dụng bạn vui lòng chọn tên khác!");
                    return res;
                }

                ProductCategoryGroupEntity entity = _context.ProductCategoryGroups
                .Include(x => x.Categories)
                .FirstOrDefault(x => x.Id == id);

                List<CategoryEntity> listorder = new List<CategoryEntity>();
                for (int i = 0; i < value.CategoryIds.Count; i++)
                {
                    var it = _context.Categories
                        .Where(x => x.Id == value.CategoryIds[i]).FirstOrDefault();
                    it.OrderLevel = i + 1;
                    listorder.Add(it);
                }
               
                value.CopyTo(entity);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.Categories = listorder;

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
                var entity = _context.ProductCategoryGroups.Find(id);
                _context.ProductCategoryGroups.Remove(entity);
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
            return _context.ProductCategoryGroups.Any(x => x.GroupName == name && (x.Id != id || id == 0));
        }

        private bool EntityExists(int id)
        {
            return _context.ProductCategoryGroups.Any(x => x.Id == id);
        }
    }
}
