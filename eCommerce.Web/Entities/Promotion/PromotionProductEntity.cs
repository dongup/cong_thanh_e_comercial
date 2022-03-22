using eCommerce.Web.Entities.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Promotion
{
    public class PromotionProductEntity : BaseEntity
    {
        public PromotionProductEntity() : base()
        {

        }

        public int PromotionId { get; set; }

        public int ProductId { get; set; }

        //public int PercentDiscount { get; set; }

        public int DiscountQuantity { get; set; }

        public int MaximumDiscount { get; set; }

        public int MinimumDiscount { get; set; }

        public int DiscountType { get; set; }

        public int SaleOffPrice { get; set; }

        [ForeignKey(nameof(PromotionId))]
        public virtual PromotionEntity Promotion { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }
    }
}