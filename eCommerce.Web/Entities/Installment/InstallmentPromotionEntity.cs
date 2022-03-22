using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Installment
{
    /// <summary>
    /// Chương trình trả góp 0%
    /// </summary>
    public class InstallmentPromotionEntity : BaseEntity
    {
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Name { get; set; }
        public int InstallmentBankId { get; set; }
        public InstallmentBankEntity InstallmentBank { get; set; }
        public ICollection<InstallmentPromotionProductEntity> InstallmenProducts { get; set; }


    }
}
