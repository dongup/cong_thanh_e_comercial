using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.Orders;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Orders;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using eCommerce.Web.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : BaseApiController
    {
        public BankController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }

        [HttpGet("admin")]
        public ResponseModel GetAdmin(string keyword = "")
        {
            try
            {
                var query = _context.Banks
                    .Where(delegate (BankEntity x)
                    {
                        return x.BankName.Like(keyword);
                    })
                    .OrderByDescending(x => x.CreatedDate)
                    .Select(x => new BankModel())
                    .ToList();

                res.Succeed(query);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        [HttpGet]
        public ResponseModel Get()
        {
            try
            {
                var query = _context.Banks
                    .OrderByDescending(x => x.CreatedDate)
                    .ToList()
                    .GroupBy(x => x.AccountName)
                    .Select(x => new {
                        AccountName = x.Key,
                        Banks = x.Select(n => new BankModel(n))
                    })
                    .ToList();

                res.Succeed(query);
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
                var result = _context.Banks
                    .Where(x => x.Id == id)
                    .Select(x => new BankModel(x))
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
        public ResponseModel Post([FromBody] BankModel value)
        {
            try
            {
                var entity = value.CopyTo(new BankEntity());
                entity.CreatedUserId = UserId;

                _context.Banks.Add(entity);

                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }

            return res;
        }

        // PUT api/Post/5
        [HttpPut("{id}")]
        public ResponseModel Put(int id, [FromBody] BankModel value)
        {
            try
            {
                var entity = _context.Banks.Find(id);
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
                }
            }

            return res;
        }

        // DELETE api/<ProductCategoryController>/5
        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.Banks.Find(id);
                _context.Banks.Remove(entity);
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
            return _context.Banks.Any(x => x.Id == id);
        }
    }
}
