using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class GiftProductResponse : BaseModel
    {
        public GiftProductResponse(GiftProductEntity entity) : base(entity)
        {
            if (entity == null) return;

            ProductId = entity.ProductId;
            GiftProductId = entity.GiftProductId;
            Product = new ProductResponse(entity.Product);
        }

        public int ProductId { get; set; }

        public int GiftProductId { get; set; }

        public virtual ProductResponse Product { get; set; }
    }
}
