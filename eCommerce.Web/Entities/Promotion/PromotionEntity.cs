using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Promotion
{
    public class PromotionEntity : BaseEntity
    {
        public PromotionEntity() : base()
        {
            PromotionProducts = new HashSet<PromotionProductEntity>();
        }

        public string Name { get; set; }

        public string Banner { get; set; }

        public string Description { get; set; }

        public string IsApplyToAll { get; set; }
        public int PriorityPromotion { get; set; }
    
        public int DiscountPercent { get; set; }

        public int DiscountQuantity { get; set; }

        public int MaximumDiscount { get; set; }

        public int MinimumDiscount { get; set; }

        public TypeDiscount DiscountType { get; set; }

        public string BackgroundColor { get; set; }

        public string BorderColor { get; set; }

        public string FriendlyUrl { get; set; }

        public int RowDisplay { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public PromoStatus Status { get; set; } = PromoStatus.Activated;
        [MaxLength(200)]
        public string StickerImage { get; set; }
        public bool IsShowSticker { get; set; }
        public enum TypeDiscount
        {
            Flat = 1,
            Percent = 2
        }

        public enum PromoStatus
        {
            Activated = 1,
            Disabled = 2
        }

        public virtual ICollection<PromotionProductEntity> PromotionProducts { get; set; }
    }
}
