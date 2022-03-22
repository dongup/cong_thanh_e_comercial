using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Installment
{
    public class InstallmentClientResponse
    {
        public string InstallmentBankLogo { get; set; }
        public int ProductPrice { get; set; }
        //public int ProductPriceInstallment { get; set; }

        /// <summary>
        /// Tiền trả góp mỗi tháng
        /// </summary>
        public int MoneyPerMonth { get; set; }

        /// <summary>
        ///  Lãi xuất , dùng object vì khi query lấy firtOrDefault().InterestRate có thể null 
        /// </summary>
        /// 
        public object InterestRateObject { get; set; }

        /// <summary>
        /// Lãi xuất
        /// </summary>
        public float? InterestRate
        {
            get
            {
                if (InterestRateObject == null) return null;
                else return (float?)InterestRateObject;
            }
        }
        /// <summary>
        /// Tổng tiền phải trả cộng cả gốc và lãi 
        /// </summary>
        public int TotalMoney { get; set; }

        /// <summary>
        ///  Chênh lệch với mua trả thẳng vs trả góp
        /// </summary>
        public int DifferencePrice { get; set; }

        /// <summary>
        /// Có hỗ trợ trả với thời hạn trả và mức trả trước gửi lên ko.
        /// </summary>
        public bool IsSupport { get; set; }
    }
}
