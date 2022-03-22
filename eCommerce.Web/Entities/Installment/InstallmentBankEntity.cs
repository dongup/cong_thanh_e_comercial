using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Installment
{

    /// <summary>
    /// Ngân hàng hỗ trợ trả góp
    /// </summary>
    public class InstallmentBankEntity : BaseEntity
    {
        public string BankName { get; set; }
        public string LogoPath { get; set; }

        /// <summary>
        /// // Giấy tờ cần thiết nhưn chứng minh, hóa đơn điện nước
        /// </summary>
        public string Papers { get; set; }

        /// <summary>
        /// Lãi xuất
        /// </summary>
        public float InterestRate { get; set; }

        /// <summary>
        /// Thời gian trả trong vòng mấy tháng .
        /// Ví dụ: 6|9|12 => Lưu theo chuỗi cách bởi đấu '|'
        /// </summary>
        public string CountMonth { get; set; }
        /// <summary>
        /// Số tiền trả trước tối thiểu
        /// </summary>
        public int MiximumPrepay { get; set; }

        /// <summary>
        /// Số tiền trả trước tối đa
        /// </summary>
        public int MaximumPrepay { get; set; }

        /// <summary>
        /// Phí làm hồ sơ
        /// </summary>
        public int PhiHoSo { get; set; }
        public ICollection<InstallmentPromotionEntity> InstallmentPromotions { get; set; }
    }
}
