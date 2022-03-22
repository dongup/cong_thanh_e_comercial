using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Entities.Installment;
using eCommerce.Web.Entities.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Orders
{
    public class OrderEntity : BaseEntity
    {
        public OrderEntity() : base()
        {
            OrderDetails = new HashSet<OrderDetailEntity>();
        }

        /// <summary>
        /// Là trả góp hay trả thẳng, 0 trả thẳng, 1 trả góp
        /// </summary>
        public bool IsInstallment { get; set; }
        public int InstallmentOrderId { get; set; }
        public virtual InstallmentOrderEntity InstallmentOrder { get; set; }
        public int CustomerId { get; set; }

        public int Status { get; set; } = (int)OrderStatus.Pending;

        public int Total { get; set; }

        public int Payment { get; set; } = (int)PaymentMethod.TienMat;

        public int? BankId { get; set; }

        public string BankAccountName { get; set; }

        public string AccountNumber { get; set; }

        public string NoiDungXuLy { get; set; }

        public int? ProcessedUserId { get; set; } = null;

        public enum OrderStatus
        {
            Pending = 1,
            Approved = 2,
            Completed = 3,
            Canceled = 4
        }

        public enum PaymentMethod
        {
            TienMat,
            ChuyenKhoan,
            TraGop
        }

        [ForeignKey(nameof(CustomerId))]
        public CustomerEntity Customer { get; set; }

        [ForeignKey(nameof(BankId))]
        public BankEntity Bank { get; set; }

        [ForeignKey(nameof(ProcessedUserId))]
        public virtual UserEntity ProcessedUser { get; set; }

        public virtual ICollection<OrderDetailEntity> OrderDetails { get; set; }
        public virtual ICollection<OrderHistoriesEntity> OrderHistories { get; set; }
    }
}
