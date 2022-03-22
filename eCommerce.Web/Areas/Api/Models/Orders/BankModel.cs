using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class BankModel : BaseModel
    {
        public BankModel()
        {

        }

        public BankModel(BankEntity entity) : base(entity)
        {
            BankName = entity.BankName;
            Logo = entity.Logo;
            AccountName = entity.AccountName;
            AccountNumber = entity.AccountNumber;
            Address = entity.Address;
        }

        public BankEntity CopyTo(BankEntity entity)
        {
            base.CopyTo(entity);
            entity.Logo = Logo;
            entity.BankName = BankName;
            entity.Address = Address;
            entity.AccountName = AccountName;
            entity.AccountNumber = AccountNumber;

            return entity;
        }

        [NotEmpty(ErrorMessage = "Vui lòng nhập tên ngân hàng")]
        public string BankName { get; set; }

        [NotEmpty(ErrorMessage = "Vui lòng chọn một logo")]
        public string Logo { get; set; }

        public string Address { get; set; }

        public string AccountName { get; set; }

        public string AccountNumber { get; set; }
    }
}
