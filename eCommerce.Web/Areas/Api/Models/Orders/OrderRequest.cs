using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Orders;
using System.Collections.Generic;
using System.Linq;
using static eCommerce.Web.Entities.Orders.OrderEntity;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class OrderRequest : BaseModel
    {
        public OrderRequest()
        {

        }

        public OrderEntity CopyTo(OrderEntity entity)
        {
            base.CopyTo(entity);
            entity.CustomerId = CustomerId;
            entity.Status = (int)OrderStatus.Pending;
            entity.Total = OrderDetailRequests.Select(x => x.BuyPrice * x.Quantity).Sum();
            entity.OrderDetails = OrderDetailRequests
                                .Select(x => x.CopyTo(new OrderDetailEntity()))
                                .ToList();
            entity.Payment = (int)PaymentMethod;

            entity.BankAccountName = BankAccountName;
            entity.BankId = BankId == 0 ? null : BankId;
            entity.AccountNumber = AccountNumber;
            entity.NoiDungXuLy = NoiDungXuLy;

            return entity;
        }
        public bool IsInstallment { get; set; }

        public int CustomerId { get; set; }

        public string AccountNumber { get; set; }

        public int? BankId { get; set; }

        public string BankAccountName { get; set; }

        public string NoiDungXuLy { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public List<OrderDetailRequest> OrderDetailRequests { get; set; }

        //Dưới này là thuộc tính cho đơn hàng trả góp
        public int InstallmentBankId { get; set; }
        public int GiaMuaTraGop { get; set; }
        public int PhanTramTraTruoc { get; set; }
        public int SoThang { get; set; }
        public float LaiXuat { get; set; }
        public int GopMoiThang { get; set; }
        public int TongTienPhaiTra { get; set; }
        public string GiayToCanCo { get; set; }
        public int PhiHoSo { get; set; }
        public int ChenhLech { get; set; }
    }
}
