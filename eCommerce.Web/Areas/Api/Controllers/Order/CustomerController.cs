using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Orders;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Order;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : BaseApiController
    {
        public CustomerController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        [HttpGet]
        public ResponseModel Get(string keyword = "", int pageItem = 12, int pageIndex = 0)
        {
            try
            {
                var query = _context.Customers
                    .Include(x => x.Orders).ThenInclude(x => x.ProcessedUser)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderHistories)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product.ProductBrand.Logo)
                    .Include(x => x.Orders).ThenInclude(x => x.InstallmentOrder)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product.ProductImages).ThenInclude(x => x.Image)
                    .Where(delegate (CustomerEntity x)
                    {
                        return x.FullName.Like(keyword) || x.Phone.Like(keyword);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new CustomerResponse(x))
                    .ToList();
                res.Succeed(new PaginationResponse<CustomerResponse>(query, pageItem, pageIndex));
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
                var result = _context.Customers
                    .Include(x => x.Orders).ThenInclude(x => x.ProcessedUser)
                     .Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product.ProductCategories).ThenInclude(x => x.Category)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product.ProductBrand.Logo)
                    .Include(x => x.Orders).ThenInclude(x => x.InstallmentOrder).ThenInclude(x=>x.InstallmentBank)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderDetails).ThenInclude(x => x.Product.ProductImages).ThenInclude(x => x.Image)
                    .Include(x => x.Orders).ThenInclude(x => x.OrderHistories)
                    .Where(x => x.Id == id)
                    .Select(x => new CustomerResponse(x))
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
        public ResponseModel Post([FromBody] CustomerRequest value)
        {
            try
            {
                var customer = _context.Customers
                    .Where(x => x.FullName.Trim().ToLower() == value.FullName.Trim().ToLower()
                                && x.Phone.Trim() == value.Phone.Trim())
                    .FirstOrDefault();
                if (customer != null)
                {
                    res.Succeed(new CustomerResponse(customer));
                }
                else
                {
                    var entity = value.CopyTo(new CustomerEntity());
                    _context.Customers.Add(entity);
                    _context.SaveChanges();
                    res.Succeed(new CustomerResponse(entity));
                }
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        [HttpDelete("{id}")]
        private ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Customers.Find(id);
                if (entity == null)
                {
                    throw NotFoundException;
                }

                _context.Customers.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {

                res.Failed(ex.Message);
            }

            return res;
        }
    }
}
