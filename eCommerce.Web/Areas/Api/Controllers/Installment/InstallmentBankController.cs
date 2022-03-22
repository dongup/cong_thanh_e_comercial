using eCommerce.Web.Areas.Api.Models.Installment;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Installment;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Controllers.HighlightProduct
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstallmentBankController : BaseApiController
    {
        public InstallmentBankController(DatabaseContext context, UserManager<UserEntity> userManager) : base(context, userManager: userManager)
        {

        }
       
        [HttpPost]
        public ResponseModel Post(InstallmentBankRequest info)
        {
            if (info.MaximumPrepay < info.MiximumPrepay)
            {
                res.Message = "Giá trị trả trước tối đa không được nhỏ hơn giá trị trả trước tối thiểu";
                return res;
            }

            var entity = new InstallmentBankEntity()
            {
                BankName = info.BankName,
                CountMonth = info.CountMonth,
                CreatedDate = DateTime.Now,
                CreatedUserId = CurrentUser.Id,
                InterestRate = info.InterestRate,
                LogoPath = info.LogoPath,
                MaximumPrepay = info.MaximumPrepay,
                MiximumPrepay = info.MiximumPrepay,
                IsDeleted = false,
                Papers = info.Papers,
                PhiHoSo = info.PhiHoSo
            };
            _context.InstallmentBanks.Add(entity);
            res.IsSuccess = _context.SaveChanges() > 0;
            return res;
        }


        [HttpDelete("{id}")]
        public ResponseModel Delete(int id)
        {
            try
            {
                var entity = _context.InstallmentBanks.Find(id);
                _context.InstallmentBanks.Remove(entity);
                _context.SaveChanges();
                res.Succeed();
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        [HttpPut]
        public ResponseModel Put(InstallmentBankRequest info)
        {
            if (info.MaximumPrepay < info.MiximumPrepay)
            {
                res.Message = "Giá trị trả trước tối đa không được nhỏ hơn giá trị trả trước tối thiểu";
                return res;
            }
            var entity = _context.InstallmentBanks.Find(info.Id);
            if (entity == null)
            {
                res.Message = "Không tìm thấy ngân hàng ";
                return res;
            }

            entity.BankName = info.BankName;
            entity.CountMonth = info.CountMonth;
            entity.CreatedDate = DateTime.Now;
            entity.CreatedUserId = CurrentUser.Id;
            entity.InterestRate = info.InterestRate;
            entity.LogoPath = info.LogoPath;
            entity.MaximumPrepay = info.MaximumPrepay;
            entity.MiximumPrepay = info.MiximumPrepay;
            entity.IsDeleted = false;
            entity.Papers = info.Papers;
            entity.PhiHoSo = info.PhiHoSo;
            res.IsSuccess = _context.SaveChanges() > 0;
            return res;
        }
        [HttpGet("get-all")]
        public ResponseModel Get()
        {
            res.Result = _context.InstallmentBanks
                .Select(n => new InstallmentBankResponse(n))
               .ToList();
            res.IsSuccess = true;
            return res;
        }
    }
}
