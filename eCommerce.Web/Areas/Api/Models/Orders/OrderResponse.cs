using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities.Order;
using eCommerce.Web.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.Orders.OrderEntity;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class OrderResponse : BaseModel
    {
        public OrderResponse()
        {

        }

        public OrderResponse(OrderEntity entity) : base(entity)
        {
            if (entity == null) return;

            CustomerId = entity.CustomerId;
            Status = entity.Status;
            Total = entity.Total;
            Customer = new SimpleCustomerResponse(entity.Customer);
            OrderDetails = entity.OrderDetails?.Select(x => new OrderDetailResponse(x)).ToList();
            AccountNumber = entity.AccountNumber;
            BankId = entity.BankId;
            PaymentMethod = (PaymentMethod)entity.Payment;
            BankAccountName = entity.BankAccountName;
            NoiDungXuLy = entity.NoiDungXuLy ?? "";
            ProcessedUser = new UserResponse(entity.ProcessedUser);
            Histories = entity.OrderHistories?.Select(n => new OrderHistoryResponse(n)).ToList();
            IsInstallment = entity.IsInstallment;
            if (IsInstallment && entity.InstallmentOrder != null)
            {
                var d = entity.InstallmentOrder;
                InstallmentOrder = new OrderInstallmentResponse()
                {
                    Price = d.Price,
                    Papers = d.Papers,
                    InterestRate = d.InterestRate,
                    PrepayPercent = d.PrepayPercent,
                    CountMonth = d.CountMonth,
                    InstallmentBankId = d.InstallmentBankId,
                    InstallmentBankName = d.InstallmentBank?.BankName,
                    PhiHoSo = d.PhiHoSo,
                    Difference = d.Difference,
                    PayPerMonth = d.PayPerMonth

                };

            }
        }

        public OrderInstallmentResponse InstallmentOrder { get; set; }
        public bool IsInstallment { get; set; }
        public string AccountNumber { get; set; }

        public int? BankId { get; set; }

        public string BankAccountName { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public int CustomerId { get; set; }

        public int Status { get; set; }

        public int Total { get; set; }

        public string NoiDungXuLy { get; set; }

        public new string CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }

        public UserResponse ProcessedUser { get; set; }

        public SimpleCustomerResponse Customer { get; set; }

        public virtual ICollection<OrderDetailResponse> OrderDetails { get; set; }
        public virtual ICollection<OrderHistoryResponse> Histories { get; set; }
    }

    public class SimpleOrderResponse : OrderResponse
    {
        public SimpleOrderResponse()
        {

        }

        public SimpleOrderResponse(OrderEntity order) : base(order)
        {

        }

        protected new virtual ICollection<OrderDetailResponse> OrderDetails { get; set; }
    }
    public class OrderInstallmentResponse
    {
        public int InstallmentBankId { get; set; }
        public string InstallmentBankName { get; set; }
        public int CountMonth { get; set; }// Số thang tra gop
        public int Price { get; set; }// Giá sản phẩm thời điểm mua 
        public float InterestRate { get; set; }// Lãi xuất hàng tháng
        public int PhiHoSo { get; set; }// Phí lam hồ sơ
        public int PrepayPercent { get; set; }// trả trước bao nhiêu 
        public string Papers { get; set; }// Giấy tờ cần có,
        public int PayPerMonth { get; set; }
        public int Difference { get; set; }// chệnh lệch giá

    }
}
