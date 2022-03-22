using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Orders;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Orders;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using static eCommerce.Web.Entities.Orders.OrderEntity;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using eCommerce.Utils.ZaloUtil;
using eCommerce.Web.Entities.Order;
using eCommerce.Web.Entities.Installment;
using System.Collections.Generic;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Areas.Api.Models.Promotion;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : BaseApiController
    {
        public OrderController(DatabaseContext context
      ) : base(context)
        {

        }

        /// <summary>
        /// Lấy tổng số đơn hàng đang chờ xử lý
        /// </summary>
        /// <returns>int: số đơn hàng</returns>
        [HttpGet("TotalPending")]
        public ResponseModel GetTotalPending()
        {
            try
            {
                var result = _context.Orders
                    .Include(x => x.Customer)
                    .Where(x => x.Status == (int)OrderStatus.Pending)
                    .Count();
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Lấy danh sách đơn đặt hàng
        /// </summary>
        /// <param name="keyword">Từ khóa tìm kiếm theo tên khách hàng, mã đơn hàng</param>
        /// <param name="statusId">Trạng thái đơn hàng</param>
        /// <param name="fromDate">Từ ngày</param>
        /// <param name="toDate">Đến ngày</param>
        /// <param name="pageItem">Số lượng bản ghi</param>
        /// <param name="pageIndex">Chỉ mục trang</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Get(string keyword = "",
            int statusId = 0,
            string fromDate = "",
            string toDate = "",
            int pageItem = 12,
            int pageIndex = 0)
        {
            try
            {
                var query = _context.Orders
                    .Include(x => x.OrderHistories)
                    .Include(x => x.Customer)
                    .Include(x => x.ProcessedUser)
                    .Where(delegate (OrderEntity x)
                    {
                        return (x.Customer.FullName.Like(keyword) || x.Id.ToString().Like(keyword) || x.Customer.Phone.Like(keyword))
                               && x.CreatedDate.Beetween(fromDate, toDate)
                               && (x.Status == statusId || statusId == 0);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new SimpleOrderResponse(x))
                    .ToList();

                res.Succeed(new PaginationResponse<SimpleOrderResponse>(query, pageItem, pageIndex));
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.StackTrace;
            }
            return res;
        }

        /// <summary>
        /// Lấy đơn hang theo mã 
        /// </summary>
        /// <param name="id">Mã đơn hàng</param>
        /// <returns></returns>
        [HttpGet("ById/{id}")]
        public ResponseModel Get(int id)
        {
            try
            {
                var result = _context.Orders
                    .Include(x => x.OrderHistories)
                    .Include(x => x.ProcessedUser)
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.Customer)
                    .Include(x => x.InstallmentOrder).ThenInclude(x=>x.InstallmentBank)
                    .Where(x => x.Id == id)
                    .Select(x => new OrderResponse(x))
                    .FirstOrDefault();
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
        /// Thêm một đơn đặt hàng
        /// </summary>
        /// <param name="value">Thông tin đơn đặt hàng</param>
        /// <returns>Trả về result là false nếu giá gửi lên chênh lệch với giá thực</returns>
        [HttpPost]
        public ResponseModel Post([FromBody] OrderRequest value)
        {
            var entity = value.CopyTo(new OrderEntity());

            try
            {

                _context.Orders.Add(entity);
                _context.SaveChanges();
                _context.Entry(entity).State = EntityState.Detached;

                var newEntity = _context.Orders
                    .Include(x => x.Customer)
                    .Include(x => x.OrderDetails).ThenInclude(x => x.Product)
                    .FirstOrDefault(x => x.Id == entity.Id);
                _context.OrderHistories.Add(MakeHistory(newEntity.Id, "Mới đặt", newEntity.Status));


                //Cập nhập giá sản phẩm vào order detail
                bool flag = true;
                foreach (var item in newEntity.OrderDetails)
                {

                    item.SellOffPrice = item.Product.SaleOffPrice;
                    item.OriginPrice = item.Product.OriginPrice;
                    //if (item.SellOffPrice != item.BuyPrice) flag = false; // Khóa lại vì giá mua đổi chua láy giá
                }

                //Nếu giá sản phẩm khác giá người dùng gửi lên thì cảnh báo
                if (!flag)
                {
                    _context.Orders.Remove(newEntity);
                    res.Result = flag;
                    throw new Exception("Giá sản phẩm bạn đặt đã thay đổi, bạn vui lòng tải lại trang web để cập nhập giá mới!");
                }

                _context.SaveChanges();

                _context.OrderNotifications.Add(new OrderNotificationEntity()
                {
                    OrderId = newEntity.Id,
                    Title = "Đơn đặt hàng mới",
                    Content = $"Khách {newEntity.Customer.FullName} vừa tạo đơn đặt hàng mới!",
                    IsSeen = false
                });
                _context.SaveChanges();

                res.Succeed(new OrderResponse(newEntity));

                SendZaloMessage(newEntity);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
                //res.Result = ex.InnerException?.Message;
                res.Result = ex.StackTrace;
            }

            return res;
        }

        /// <summary>
        /// Thêm một đơn đặt hàng trả góp
        /// </summary>
        /// <param name="value">Thông tin đơn đặt hàng</param>
        /// <returns>Trả về result là false nếu giá gửi lên chênh lệch với giá thực</returns>
        [HttpPost("PostInstallment")]
        public ResponseModel PostInstallment([FromBody] OrderRequest value)
        {
            var entity = value.CopyTo(new OrderEntity());

            var productId = value.OrderDetailRequests.FirstOrDefault().ProductId;
            var product = _context.Products.Where(x=>x.Id== productId).Select(x=>new ProductResponse(x)).FirstOrDefault();
            //var productResponse = new ProductResponse(product);
            //Nếu giá sản phẩm khác giá người dùng gửi lên thì cảnh báo
            if (product.GiaBanLe != value.GiaMuaTraGop)
            {
                 res.Failed("Giá sản phẩm bạn đặt đã thay đổi, bạn vui lòng tải lại trang web để cập nhập giá mới!");
                return res;
            }

            var entityorder = new OrderEntity();
            entityorder.CustomerId = value.CustomerId;
            entityorder.Payment = (int)PaymentMethod.TraGop;
            entityorder.Status = (int)OrderStatus.Pending;
            //entityorder.Total = value.OrderDetailRequests.Select(x => x.BuyPrice * x.Quantity).Sum();
            //entityorder.Total= value.GiaMuaTraGop;
            List<OrderDetailEntity> list = new List<OrderDetailEntity>();
            list.Add(new OrderDetailEntity { BuyPrice = value.GiaMuaTraGop, Quanity = 1, ProductId = productId });
            entityorder.OrderDetails = list;


            entityorder.Total = value.TongTienPhaiTra;
            entityorder.IsInstallment = true;
            _context.Orders.Add(entityorder);
            _context.SaveChanges();
            var newOrder = _context.Orders.Find(entityorder.Id);
            var orderInstallment = new InstallmentOrderEntity()
            {
                InstallmentBankId = value.InstallmentBankId,
                CountMonth = value.SoThang,
                Price = value.GiaMuaTraGop,
                InterestRate = value.LaiXuat,
                PhiHoSo = value.PhiHoSo,
                PrepayPercent = value.PhanTramTraTruoc,
                CreatedDate = DateTime.Now,
                Papers = value.GiayToCanCo,
                Difference = value.ChenhLech,
                PayPerMonth = value.GopMoiThang

            };
            orderInstallment.OrderId = newOrder.Id;
            _context.InstallmentOrders.Add(orderInstallment);
            _context.SaveChanges();
            newOrder.InstallmentOrderId = orderInstallment.Id;
            var customer = _context.Customers.FirstOrDefault(n => n.Id == value.CustomerId);
            _context.OrderNotifications.Add(new OrderNotificationEntity()
            {
                OrderId = newOrder.Id,
                Title = "Đơn đặt hàng mới",
                Content = $"Khách {customer.FullName} vừa tạo đơn đặt hàng mới!",
                IsSeen = false
            });
            _context.SaveChanges();
            res.Succeed(new OrderResponse(newOrder));
            try
            {
                SendZaloMessage(newOrder);
            }
            catch (Exception)
            {

            }

            return res;

        }
        //public int OrderId { get; set; }
        //[ForeignKey(nameof(OrderId))]
        //public virtual OrderEntity Order { get; set; }
        //public int InstallmentBankId { get; set; }
        //public int CountMonth { get; set; }// Số thang tra gop
        //public int Price { get; set; }// Giá sản phẩm thời điểm mua 
        //public double InterestRate { get; set; }// Lãi xuất hàng tháng
        //public int PhiHoSo { get; set; }// Phí lam hồ sơ
        //public int PrepayPercent { get; set; }// trả trước bao nhiêu %
        /// <summary>
        /// Thay đổi trạng thái đơn hàng
        /// </summary>
        /// <param name="id">Mã đơn hàng</param>
        /// <param name="statusId">Trạng thái mới</param>
        /// <returns></returns>
        [HttpPut("UpdateStatus/{id}")]
        public ResponseModel Put(int id, int statusId, string note)
        {
            try
            {
                var entity = _context.Orders.Find(id);
                entity.Status = statusId;
                entity.UpdatedUserId = UserId;
                entity.UpdatedDate = now;
                entity.ProcessedUserId = UserId;
                entity.NoiDungXuLy = note;
                _context.OrderHistories.Add(MakeHistory(entity.Id, note, entity.Status));

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

        ///// <summary>
        ///// Thay đổi trạng thái đơn hàng
        ///// </summary>
        ///// <param name="id">Mã đơn hàng</param>
        ///// <param name="note">Nội dung xử lý</param>
        ///// <returns></returns>
        //[HttpPut("Approve/{id}")]
        //public ResponseModel ApproveOrder(int id, string note)
        //{
        //    try
        //    {


        //        var entity = _context.Orders.Find(id);
        //        entity.Status = (int)OrderStatus.Approved;
        //        entity.NoiDungXuLy = note;

        //        entity.UpdatedUserId = UserId;
        //        entity.UpdatedDate = now;
        //        _context.OrderHistories.Add(MakeHistory(entity.Id, note, entity.Status));

        //        _context.SaveChanges();

        //        res.Succeed();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!EntityExists(id))
        //        {
        //            res.NotFound();
        //        }
        //        else
        //        {
        //            res.Failed(ex.Message);
        //        }
        //    }

        //    return res;
        //}

        ///// <summary>
        ///// Thay đổi trạng thái đơn hàng
        ///// </summary>
        ///// <param name="id">Mã đơn hàng</param>
        ///// <param name="note">Lý do hủy</param>
        ///// <returns></returns>
        //[HttpPut("Cancel/{id}")]
        //public ResponseModel CancelOrder(int id, [FromBody] string note)
        //{
        //    try
        //    {
        //        var entity = _context.Orders.Find(id);
        //        entity.Status = (int)OrderStatus.Canceled;
        //        entity.Note = note;

        //        entity.UpdatedUserId = UserId;
        //        entity.UpdatedDate = now;
        //        _context.OrderHistories.Add(MakeHistory(entity.Id, note, entity.Status));
        //        _context.SaveChanges();

        //        res.Succeed();
        //    }
        //    catch (Exception ex)
        //    {
        //        if (!EntityExists(id))
        //        {
        //            res.NotFound();
        //        }
        //        else
        //        {
        //            res.Failed(ex.Message);
        //        }
        //    }

        //    return res;
        //}

        [HttpDelete("{id}")]
        private ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Orders.Find(id);

                _context.Orders.Remove(entity);
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

        private void SendZaloMessage(OrderEntity order)
        {
            ZaloUtil zalo = new ZaloUtil(_context);

            zalo.SendOrderMessage(order);
        }

        OrderHistoriesEntity MakeHistory(int orderId, string content, int stt)
        {
            return new OrderHistoriesEntity()
            {
                OrderId = orderId,
                Content = content,
                StatusOrder = stt,
                CreatedUserName = CurrentUser.FullName,
                UpdatedUserId = CurrentUser.Id,
                CreatedDate = DateTime.Now
            };
        }
        private bool EntityExists(int id)
        {
            return _context.Orders.Any(x => x.Id == id);
        }
    }
}
