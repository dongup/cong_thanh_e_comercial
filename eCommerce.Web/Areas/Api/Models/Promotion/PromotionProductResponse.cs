using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities.Promotion;

namespace eCommerce.Web.Areas.Api.Models.Promotion
{
    public class PromotionProductResponse : BaseModel
    {
        public PromotionProductResponse()
        {

        }

        public PromotionProductResponse(PromotionProductEntity entity) : base(entity)
        {
            PromotionId = entity.PromotionId;
            ProductId = entity.ProductId;
            DiscountQuantity = entity.DiscountQuantity;
            MaximumDiscount = entity.MaximumDiscount;
            DiscountType = entity.DiscountType;
            SaleOffPrice = entity.SaleOffPrice;
            Product = new SimpleProductResponse(entity.Product);
            ProductName = Product.ProductName;
            Thumbnail = Product.ThumbNail;
            OriginPrice = Product.OriginPrice;

        }

        public int GiaBanLe { get; set; }
        public string ProductName { get; set; }

        public string Thumbnail { get; set; }

        public int PromotionId { get; set; }

        public int ProductId { get; set; }

        public int OriginPrice { get; set; }

        public int DiscountQuantity { get; set; }

        public int MaximumDiscount { get; set; }

        public int MinimumDiscount { get; set; }

        public int DiscountType { get; set; }

        public int SaleOffPrice { get; set; }

        public SimpleProductResponse Product { get; set; }
    }
}
