using eCommerce.Web.Entities.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Installment
{
    /// <summary>
    ///    Đơn hàng trả góp tham chiếu sản phẩm từ tbl Đơn hàng, 
    /// </summary>
    public class InstallmentOrderEntity : BaseEntity
    {
        
        public int OrderId { get; set; }
        [ForeignKey(nameof(OrderId))]
        public virtual OrderEntity Order { get; set; }
        public int InstallmentBankId { get; set; }
        public virtual InstallmentBankEntity InstallmentBank { get; set; }
        public int CountMonth { get; set; }// Số thang tra gop
        public int Price { get; set; }// Giá sản phẩm thời điểm mua 
        public float InterestRate { get; set; }// Lãi xuất hàng tháng
        public int PhiHoSo { get; set; }// Phí lam hồ sơ
        public int PrepayPercent { get; set; }// trả trước bao nhiêu %
        public string Papers { get; set; }// Giấy tờ cần có
        public int Difference { get; set; }// chenh lệch
        public int PayPerMonth { get; set; }



    }
}
