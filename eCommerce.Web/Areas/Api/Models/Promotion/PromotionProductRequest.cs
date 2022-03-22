using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities.Promotion;

namespace eCommerce.Web.Areas.Api.Models.Promotion
{
    public class PromotionProductRequest : PromotionProductResponse
    {
        public PromotionProductRequest()
        {

        }

        public PromotionProductEntity CopyTo(PromotionProductEntity entity)
        {
            base.CopyTo(entity);
            entity.ProductId = ProductId;
            //entity.PercentDiscount = PercentDiscount;
            entity.DiscountQuantity = DiscountQuantity;
            entity.MaximumDiscount = MaximumDiscount;
            entity.MinimumDiscount = MinimumDiscount;
            entity.DiscountType = DiscountType;
            entity.SaleOffPrice = SaleOffPrice;

            return entity;
        }

        //protected new PromotionResponse Promotion { get; set; }
        protected new SimpleProductResponse Product { get; set; }
    }
}
