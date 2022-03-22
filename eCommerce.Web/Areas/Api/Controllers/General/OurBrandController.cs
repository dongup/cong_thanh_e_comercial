using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OurBrandController : BaseApiController
    {
        public OurBrandController(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// Lấy danh sách popup dựa theo keyword tìm kiếm
        /// </summary>
        /// <param name="keyword">Từ khóa theo tiêu đề và phụ đề</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword)
        {
            try
            {
                var result = _context.Popups
                    .Include(x => x.Image)
                    .Where(delegate (PopupEntity x) {
                        return x.Title.Like(keyword)
                            || x.SubTitle.Like(keyword);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new PopupResponse(x))
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
                var result = _context.Popups
                    .Include(x => x.Image)
                    .Where(x => x.Id == id)
                    .Select(x => new PopupResponse(x))
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
        public ResponseModel Post([FromBody] PopupRequest value)
        {
            try
            {
                var entity = value.CopyTo(new PopupEntity());
                entity.CreatedUserId = UserId;

                _context.Popups.Add(entity);
                _context.SaveChanges();

                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.InnerException.Message;
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] PopupRequest value)
        {
            try
            {
                var entity = value.CopyTo(new PopupEntity());
                entity.Id = id;
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                _context.Entry(entity).State = EntityState.Modified;
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
                var entity = _context.Popups.Find(id);
                _context.Popups.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        } 

        private bool EntityExists(int id)
        {
            return _context.Popups.Any(x => x.Id == id);
        }
    }
}
