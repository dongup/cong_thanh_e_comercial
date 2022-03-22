using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.General;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class PostCategoryController : BaseApiController
    {

        public PostCategoryController(DatabaseContext context, UserManager<UserEntity> userManager = null) : base(context, userManager: userManager)
        {

        }

        [HttpGet]
        public ResponseModel Get(string keyword = "")
        {
            try
            {
                var result = _context.PostCategories
                    .Include(x => x.Posts)
                    .Where(delegate (PostCategoryEntity x)
                    {
                        return x.Name.Like(keyword);
                    })
                    .Select(x => new PostCategoryResponse(x))
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
                var result = _context.PostCategories
                    .Where(x => x.Id == id)
                    .Select(x => new PostCategoryResponse(x))
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
        public ResponseModel Post([FromBody] PostCategoryRequest value)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var entity = value.CopyTo(new PostCategoryEntity());
                entity.CreatedUserId = UserId;

                AddUrl(UrlType.PostCategory, value.FriendlyUrl);

                _context.PostCategories.Add(entity);
                _context.SaveChanges();

                res.Succeed();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] PostCategoryRequest value)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.PostCategories.Find(id);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                UpdateUrl(entity.FriendlyUrl, value.FriendlyUrl, UrlType.PostCategory);

                value.CopyTo(entity);

                _context.SaveChanges();
                res.Succeed();
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

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            var trans = _context.Database.BeginTransaction();
            try
            {
                var entity = _context.PostCategories.Find(id);
                _context.PostCategories.Remove(entity);

                DeleteUrl(entity.FriendlyUrl);

                _context.SaveChanges();
                res.Succeed();
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                res.Failed(ex.Message);
            }

            return res;
        }

        private bool EntityExists(int id)
        {
            return _context.PostCategories.Any(x => x.Id == id);
        }
    }
}
