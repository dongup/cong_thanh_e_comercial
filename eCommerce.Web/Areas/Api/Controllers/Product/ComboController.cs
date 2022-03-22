using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.ComboProduct;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Product.ComboProduct;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComboController : BaseApiController
    {
        public ComboController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy ra danh sách combo
        /// </summary>
        /// <param name="keyword">Từ khóa tìm theo danh mục sản phẩm</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel GetAdmin(
            int sortOrder = 1,
            string keyword = "",
            int fromPrice = 0,
            int toPrice = 0,
            int pageIndex = 0,
            int pageItem = 20)
        {
            try
            {
                string order = "";
                if (sortOrder == 0)
                    order = "Price ASC";
                else
                    order = "Price DESC ";

                var query = _context.Combos
                    .Include(x => x.ComboProducts)
                    .ThenInclude(x => x.Product)
                    .Include(x => x.ComboImages)
                    .ThenInclude(x => x.Image)
                    .OrderBy(order)
                    .Where(delegate (ComboEntity x)
                    {
                        return x.Name.Like(keyword)
                        && (x.Price >= fromPrice || fromPrice == 0)
                        && (x.Price <= toPrice || toPrice == 0);
                    })
                    .Select(x => new ComboResponse(x));
                //.Select(x => x.IsNewUpdatePrice);

                res.Succeed(new PaginationResponse<ComboResponse>(query.ToList(), pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpGet("{id}")]
        public ResponseModel Get(int id)
        {
            try
            {
                var result = _context.Combos
                    .Include(x => x.ComboProducts)
                    .ThenInclude(x => x.Product)
                    .Include(x => x.ComboImages)
                    .ThenInclude(x => x.Image)
                    .Where(x => x.Id == id)
                    .Select(x => new ComboResponse(x))
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
        /// Tạo combo sản phẩm mới
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]
        public ResponseModel Post([FromBody] ComboRequest value)
        {
            try
            {
                if (_context.Products.Where(n => n.FriendlyUrl == value.FriendlyUrl).FirstOrDefault() != null)
                    throw new Exception("Tên đường dẫn đã tồn tại");
                var thumbnail = _context.Files.Where(n => n.Id == value.ImageIds.FirstOrDefault()).FirstOrDefault().ThumbNailPath;
                var entity = value.CopyTo(new ComboEntity());
                entity.CreatedUserId = UserId;
                entity.ThumbnailPath = thumbnail;
                _context.Combos.Add(entity);
                _context.SaveChanges();

                var originPrice = 0;
                var combo = _context.Combos
                    .Include(n => n.ComboProducts).ThenInclude(n => n.Product)
                    .Where(n => n.Id == entity.Id)
                    .FirstOrDefault(); ;
                foreach (var item in combo.ComboProducts)
                {
                    originPrice += (item.Product.OriginPrice * item.Quantity);
                }
                var pro = new ProductEntity()
                {
                    ComboId = entity.Id,
                    FriendlyUrl = entity.FriendlyUrl,
                    Description = entity.Description,
                    GurantyTime = entity.GurantyTime,
                    IsCombo = true,
                    SaleOffPrice = entity.Price,
                    CreatedUserId = UserId,
                    ThumbNail = thumbnail,
                    ProductName = entity.Name,
                    PromotionContent = entity.PromoContent,
                    OriginPrice = originPrice
                };
                _context.Products.Add(pro);
                _context.SaveChanges();

                res.Succeed(new ComboResponse(entity));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] ComboRequest value)
        {
            try
            {
                ComboEntity entity = _context.Combos
                .Include(n => n.ComboProducts)
                .Include(n => n.ComboImages)
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
                    //res.Result = ex.StackTrace;
                }
            }

            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Combos.Find(id);

                _context.Combos.Remove(entity);
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

        private bool EntityExists(int id)
        {
            return _context.Combos.Any(x => x.Id == id);
        }
    }
}
