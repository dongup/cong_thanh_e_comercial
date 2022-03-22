using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Orders;
using eCommerce.Web.Areas.Api.Models.Posts;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.General;
using eCommerce.Web.Entities.Orders;
using eCommerce.Web.Entities.Post;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderNotificationController : BaseApiController
    {
        public OrderNotificationController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        /// <summary>
        /// Lấy danh sách đơn đặt hàng
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tên khách hàng</param>
        /// <param name="statusId">Trạng thái đơn hàng</param>
        /// <param name="fromDate">Từ ngày</param>
        /// <param name="toDate">Đến ngày</param>
        /// <param name="pageItem">Số lượng bản ghi</param>
        /// <param name="pageIndex">Chỉ mục trang</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword = "",
            string fromDate = "",
            string toDate = "",
            int pageItem = 10,
            int pageIndex = 0,
            int statusId = 0)
        {
            try
            {
                var query = _context.OrderNotifications
                    .Include(x => x.Order.Customer)
                    .Where(delegate (OrderNotificationEntity x)
                    {
                        return (x.Order.Customer.FullName.Like(keyword)
                        || x.Order.Id.ToString().Like(keyword))
                        && x.CreatedDate.Beetween(fromDate, toDate)
                        && (x.Order.Status == statusId || statusId == 0);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new OrderNotificationResponse(x))
                    .ToList();

                res.Succeed(new PaginationResponse<OrderNotificationResponse>(query, pageItem, pageIndex));
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
                var result = _context.Orders
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.Customer)
                    .Where(x => x.Id == id)
                    .Select(x => new OrderResponse(x))
                    .FirstOrDefault();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.OrderDetails.Find(id);
                _context.OrderDetails.Remove(entity);
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

        private bool EntityExists(int id)
        {
            return _context.OrderDetails.Any(x => x.Id == id);
        }
    }
}
