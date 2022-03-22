using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Products.Property;
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

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValueController : BaseApiController
    {
        public ValueController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra danh sách danh mục kèm theo các template của danh mục đó
        /// </summary>
        /// <param name="keyword">Từ khóa tìm theo danh mục sản phẩm</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.Values
                    .Where(delegate (ValueEntity x)
                    {
                        return x.Value.Like(keyword);
                    })
                    .Select(x => new ValueModel(x))
                    .ToList();
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
                var result = _context.Values
                    .Where(x => x.Id == id)
                    .Select(x => new ValueModel(x))
                    .FirstOrDefault();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Tạo giá trị mới
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseModel Post([FromBody] ValueModel value)
        {
            try
            {
                if (EntityExists(value.Value, value.PropertyId))
                {
                    res.Failed("Giá trị thuộc tính này đã được sử dụng vui lòng chọn giá trị khác!");
                    return res;
                }

                var entity = value.CopyTo(new ValueEntity());
                entity.CreatedUserId = UserId;

                _context.Values.Add(entity);
                _context.SaveChanges();

                res.Succeed(new ValueModel(entity));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Tạo nhiều giá trị mới, trả về danh sách các id của giá trị
        /// </summary>
        /// <param name="values">Danh sách các giá trị mới</param>
        /// <returns></returns>
        [HttpPost("Mutile")]
        public ResponseModel Mutiple([FromBody] List<ValueModel> values)
        {
            try
            {
                var entities = values.Select(x => new ValueEntity() { 
                    Value = x.Value,
                    CreatedUserId = UserId,
                    PropertyId = x.PropertyId == 0? null : x.PropertyId
                });

                List<int> Ids = new List<int>();
                foreach(var item in entities)
                {
                    var existedItem = _context.Values.FirstOrDefault(x => x.Value == item.Value && x.PropertyId == item.PropertyId);
                    if (existedItem != null)
                    {
                        Ids.Add(existedItem.Id);
                        continue;
                    }
                    else
                    {
                        _context.Values.Add(item);
                        _context.SaveChanges();
                        Ids.Add(item.Id);
                    }
                }

                var result = Ids;

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.InnerException.Message;
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] ValueModel value)
        {
            try
            {
                if (EntityExists(value.Value, value.PropertyId, id))
                {
                    res.Failed("Giá trị thuộc tính này đã tồn tại vui lòng chọn giá trị khác!");
                    return res;
                }

                ValueEntity entity = _context.Values
                .FirstOrDefault(x => x.Id == id);

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
                var entity = _context.Values.Find(id);

                _context.Values.Remove(entity);
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

        private bool EntityExists(string value, int? propId = 0, int id = 0)
        {
            return _context.Values.Any(x => x.Value == value && (x.Id != id || id == 0) && (propId == 0 || x.PropertyId == propId));
        }

        private bool EntityExists(int id)
        {
            return _context.Values.Any(x => x.Id == id);
        }
    }

}
