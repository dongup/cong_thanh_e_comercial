using eCommerce.Web.Areas.Api.Models;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.General;
using eCommerce.Web.Entities.Generals;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroduceController : BaseApiController
    {
        public IntroduceController(DatabaseContext context, UserManager<UserEntity> userManager = null) : base(context, userManager: userManager)
        {

        }

        [HttpGet]
        public ResponseModel Get()
        {
            try
            {
                var query = _context.Introduce
                    .Include(x => x.Post.Banner)
                    .Include(x => x.Post.PostCategory)
                    .FirstOrDefault();
                var result = new IntroduceResponse();
                result.Brands = _context.ProductBrands
                    .Include(n => n.Logo)
                    .OrderBy(n => n.Order)
                    .Select(n => new ProductBrandResponse(n))
                    .ToList();
                List<int> imageIds = query.BannerImages?.Split(',')?.Select(x => int.Parse(x))?.ToList();
                //List<int> categoryIds = query.ProductCategories?.Split(',')?.Select(x => int.Parse(x))?.ToList();

                if (imageIds != null)
                {
                    result.BannerImages = _context.Files
                        .Where(x => imageIds.Contains(x.Id))
                        .Select(x => new FileResponse(x))
                        .ToList();
                }


                result.ProductCategories = _context.Categories
                    .Select(x => new CategoryResponse(x))
                    .ToArray();

                result.Introduction = query.Introduction;
                result.Post = new Models.Posts.PostResponse(query.Post);

                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpPut]
        public async Task<ResponseModel> Put([FromBody] IntroduceRequest value)
        {
            try
            {
                IntroduceEntity entity = _context.Introduce.Include(x => x.Post).FirstOrDefault();
                value.CopyTo(entity);
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;

                await _context.SaveChangesAsync();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                res.Result = ex.StackTrace;
            }

            return res;
        }
    }
}
