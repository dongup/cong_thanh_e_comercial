using eCommerce.Web.Areas.Api.Models.Cart;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Controllers.Cart
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseApiController
    {
        public CartController(DatabaseContext context) : base(context)
        {
        }

        [HttpGet()]
        public ResponseModel Get()
        {
            try
            {
                var result = _context.Carts
                    .Where(n => n.CustomerId == UserId)
                    .Select(n => new CartResponseModel()
                    {
                        Id = n.Id,
                        ProductId = n.ProductId,
                        GiaBanLe = n.Product.GiaBanLe,
                        OriginPrice = n.Product.OriginPrice,
                        ProductName = n.Product.ProductName,
                        Quantity = n.Quantity
                    });
                res.Succeed(result);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }


        /// <summary>
        /// Thêm sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost()]
        public ResponseModel Post(CartRequestModel model)
        {
            try
            {
                var entity = _context.Carts
                    .Where(n => n.CustomerId == UserId && n.ProductId == model.ProductId)
                    .SingleOrDefault();
                if (entity == null)
                {
                    entity = new Entities.Orders.CartEntity()
                    {
                        ProductId = model.ProductId,
                        CreatedDate = DateTime.Now,
                        CustomerId = UserId,
                        CreatedUserId = UserId
                    };
                    _context.Carts.Add(entity);
                    res.Succeed();
                }
                else
                {
                    entity.Quantity += 1;
                }
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        /// <summary>
        /// Xóa sản phẩm trong giỏ hàng
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpDelete("{Id}")]
        public ResponseModel Delete(int Id)
        {
            try
            {
                var entity = _context.Carts.Find(Id);
                if (entity != null)
                    _context.Carts.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch
            {
                res.Failed();
            }

            return res;
        }

        /// <summary>
        /// Trừ số lượng sản phẩm trong giỏ hàng, nếu + sẽ vào post 
        /// </summary>
        /// <param name="Id">CartId</param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        public ResponseModel Put(int Id)
        {
            try
            {
                var entity = _context.Carts.Find(Id);
                if (entity != null)
                {
                    if (entity.Quantity > 1)
                        entity.Quantity -= 1;
                }
                _context.SaveChanges();
                res.Succeed();

            }
            catch
            {
                res.Failed();
            }

            return res;
        }

    }
}
