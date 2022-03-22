using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Products.Property;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseApiController
    {
        public PropertyController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy danh sách thuộc tính nhóm theo bảng chữ cái
        /// </summary>
        /// <returns></returns>
        [HttpGet("Alphabet")]
        public ResponseModel GetAlphabet()
        {
            try
            {
                var result = _context.Properties
                    .OrderBy(x => x.PropertyName)
                    .AsEnumerable()
                    .GroupBy(x => x.PropertyName.FirstOrDefault())
                    .Select(x => new
                    {
                        Letter = x.FirstOrDefault().PropertyName.FirstOrDefault(),
                        Properties = x.Select(n => new PropertyResponse(n))
                    })
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
        /// Lấy danh sách theo danh mục id
        /// </summary>
        /// <returns></returns>
        [HttpGet("ByCategory/{id}")]
        public ResponseModel ByCategory(int id)
        {
            try
            {
                var result = _context.Properties
                    .Include(x => x.Values)

                    .Where(n => n.CategoryId == id)
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new PropertyResponse(x))
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
        /// Lấy danh sách theo nhiều  danh mục, dạng 1,2
        /// </summary>
        /// <returns></returns>
        [HttpGet("ByCategoryMultiple/{id}")]
        public ResponseModel ByCategoryMultiple(string id)
        {
            try
            {
                var ids = id.Split();

                var result = _context.Properties
                    .Include(x => x.Values)
                    .Where(n => ids.Contains(n.CategoryId.ToString()))
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new PropertyResponse(x))
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
        /// Lấy danh sách nhưng thuộc tính là filter trong danh mục
        /// <param name="id">Mã danh mục</param>
        /// </summary>
        /// <returns></returns>
        [HttpGet("IsFilter/{id}")]
        public ResponseModel IsFilter(int id)
        {
            try
            {
                var result = _context.Properties
                  .Include(x => x.Values)
                  .ThenInclude(x => x.Value)
                  .Where(x => x.CategoryId == id
                            && x.IsFilter)
                  .Select(x => new PropertyFilterResponse(x))
                  .FirstOrDefaultAsync();

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpGet]
        public ResponseModel Get(string keyword)
        {
            try
            {
                var result = _context.Properties
                    .Include(x =>x.Category)
                    .Include(x => x.Values)
                    .Include(x => x.PropertyTemplates).ThenInclude(x => x.Template).ThenInclude(x => x.ProductCategory)
                    .Where(delegate (PropertyEntity x)
                    {
                        return x.PropertyName.Like(keyword);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new PropertyResponse(x))
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
                var result = _context.Properties
                    .Include(x => x.Values)
                    .Where(x => x.Id == id)
                    .Select(x => new PropertyResponse(x))
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
        public ResponseModel Post([FromBody] PropertyRequest value)
        {
            try
            {
                if (EntityExists(value.PropertyName, 0, value.CategoryId))
                {
                    res.Failed("Tên thuộc tính này đã được sử dụng vui lòng chọn tên khác!");
                    return res;
                }

                var entity = value.CopyTo(new PropertyEntity());
                entity.CreatedUserId = UserId;
                entity.Values = _context.Values.Where(x => value.ValueIds.Contains(x.Id)).ToList();

                _context.Properties.Add(entity);
                _context.SaveChanges();

                res.Succeed(new PropertyResponse(entity));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.InnerException.Message;
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] PropertyRequest value)
        {
            try
            {
                if (EntityExists(value.PropertyName, id, value.CategoryId))
                {
                    res.Failed("Tên thuộc tính này đã được sử dụng vui lòng chọn tên khác!");
                    return res;
                }

                var entity = _context.Properties
                    .Include(x => x.Values)
                    .Where(x => x.Id == id).FirstOrDefault();

                value.CopyTo(entity);

                entity.Values = _context.Values.Where(x => value.ValueIds.Contains(x.Id)).ToList();
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                _context.SaveChanges();
                res.Succeed(new PropertyResponse(entity));
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
                var entity = _context.Properties.Find(id);
                _context.Properties.Remove(entity);
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

        [HttpPut("setFilter/{id}")]
        public ResponseModel SetFilter(int id, [FromBody] SetFilterRequest values)
        {
            try
            {
                var entity = _context
                    .Properties
                    .Include(n => n.Values)
                    .Where(n => n.Id == id)
                    .FirstOrDefault();
                if (entity == null)
                    res.NotFound();
                else
                {
                    var list = entity.Values.ToList();
                    int count = list.Count;
                    entity.IsFilter = values.Type;
                    for (int i = 0; i < count; i++)
                    {
                        if (values.Type)
                        {
                            if (values.ValueIds.Contains(list[i].Id))
                                list[i].IsFilter = true;
                            else
                                list[i].IsFilter = false;
                        }
                        else
                        {
                            list[i].IsFilter = false;
                        }
                    }
                }
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

        private bool EntityExists(string name, int id = 0, int? catId = 0)
        {
            return _context.Properties.Any(x => x.PropertyName == name && (x.Id != id || id == 0) && (x.CategoryId == catId || catId == 0));
        }

        private bool EntityExists(int id)
        {
            return _context.Properties.Any(x => x.Id == id);
        }
    }
}
