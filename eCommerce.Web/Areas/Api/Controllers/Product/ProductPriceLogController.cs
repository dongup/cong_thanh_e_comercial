using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities.Product;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using eCommerce.Web.Entities.Identity;

namespace eCommerce.Web.Areas.Api.Controllers.Product
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceLogController : BaseApiController
    {
        public ProductPriceLogController(DatabaseContext context,
            IConfiguration config = null,
            IWebHostEnvironment webHost = null,
            UserManager<UserEntity> userManager = null) : base(context, config, webEnv: webHost, userManager: userManager)
        {

        }


        /// <summary>
        /// Lịch sử giá của sản phẩm
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tên sản phẩm</param>
        /// <param name="updatedUserId">Mã người cập nhập</param>
        /// <param name="fromDate">Từ ngày</param>
        /// <param name="toDate">Đến ngày</param>
        /// <param name="pageIndex">Chỉ mục trang</param>
        /// <param name="pageItem">Số dòng lấy</param>
        /// <returns></returns>
        [HttpGet("ProductPriceLogs")]
        public ResponseModel ProductPriceLogs(
            string keyword = "",
            int updatedUserId = 0,
            string fromDate = "",
            string toDate = "",
            int pageIndex = 0,
            int pageItem = 10)
        {
            try
            {
                var query = _context.ProductPriceLogs
                    .Include(x => x.Product.ProductBrand.Logo)
                    .Include(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                    .OrderByDescending(x => x.CreatedDate)
                    .Where(delegate (ProductPriceLogEntity x)
                    {
                        return x.Product.ProductName.Like(keyword)
                        && x.CreatedDate.Beetween(fromDate, toDate)
                        && (x.UpdatedUserId == updatedUserId || updatedUserId == 0);
                    })
                    .Select(x => new ProductPriceLogResponse(x)
                    {
                        UpdatedUser = new UserResponse(_context.Users
                                        .Include(x => x.UserRoles).ThenInclude(x => x.Role)
                                        .FirstOrDefault(a => x.CreatedUserId == a.Id))
                    })
                    .ToList();

                res.Succeed(new PaginationResponse<ProductPriceLogResponse>(query, pageItem, pageIndex));
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
                var query = _context.ProductPriceLogs
                     .Include(x => x.Product.ProductBrand.Logo)
                     .Include(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                     .Where(x => x.Id == id)
                     .ToList()
                     .Select(x => new DetailProductPriceLogResponse(x)
                     {
                         UpdatedUser = GetUser(x.CreatedUserId)
                     })
                     .FirstOrDefault();

                res.Succeed(query);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }

            return res;
        }

        [HttpGet("ByProductId/{id}")]
        public ResponseModel ByProductId(int id)
        {
            try
            {
                var query = _context.ProductPriceLogs
                     .Include(x => x.Product.ProductBrand.Logo)
                     .Include(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                     .Where(x => x.Product.Id == id)
                     .ToList()
                     .Select(x => new DetailProductPriceLogResponse(x)
                     {
                         UpdatedUser = GetUser(x.CreatedUserId)
                     });

                res.Succeed(query);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }

            return res;
        }
    }
}
