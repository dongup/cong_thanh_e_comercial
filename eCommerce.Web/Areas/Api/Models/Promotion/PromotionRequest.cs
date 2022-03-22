using eCommerce.Utils;
using eCommerce.Web.Entities.Promotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Promotion
{
    public class PromotionRequest : PromotionResponse
    {
        public PromotionRequest()
        {

        }

        public PromotionEntity CopyTo(PromotionEntity entity)
        {
            base.CopyTo(entity);
            entity.Name = Name;
            entity.BackgroundColor = BackgroundColor;
            entity.Banner = Banner;
            entity.Description = Description;
            entity.PriorityPromotion = Priority;
            entity.DiscountPercent = DiscountPercent;
            entity.DiscountType = (PromotionEntity.TypeDiscount)DiscountType;
            entity.DiscountQuantity = DiscountQuantity;
            entity.MaximumDiscount = MaximumDiscount;
            entity.MinimumDiscount = MinimumDiscount;
            entity.StartDate = (DateTime)StartDate.ToDateTime();
            entity.EndDate = (DateTime)EndDate.ToDateTime();
            entity.FriendlyUrl = FriendlyUrl;
            entity.RowDisplay = RowDisplay;
            entity.PromotionProducts = PromotionProductRequests.Select(x => x.CopyTo(new PromotionProductEntity())).ToList();
            entity.StickerImage = StickerImage == "#" ? null : StickerImage;
            entity.IsShowSticker = IsShowSticker ;
            entity.BorderColor = BorderColor;
            return entity;
        }

        public List<PromotionProductRequest> PromotionProductRequests { get; set; } = new List<PromotionProductRequest>();

        protected new virtual ICollection<PromotionProductResponse> PromotionProducts { get; set; }
    }
}
