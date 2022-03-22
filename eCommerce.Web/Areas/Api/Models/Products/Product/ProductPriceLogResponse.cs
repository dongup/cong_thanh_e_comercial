using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities.Product;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class ProductPriceLogResponse : BaseModel
    {
        public ProductPriceLogResponse()
        {

        }

        public ProductPriceLogResponse(ProductPriceLogEntity entity) : base(entity)
        {
            ProductId = entity.ProductId;
            PublicPrice = entity.PublicPrice;
            OriginPrice = entity.OriginPrice;
            SaleOffPrice = entity.SaleOffPrice;
            GiaBanLe = entity.GiaBanLe;
            SaleOffPriceOld = entity.SaleOffPriceOld;
            OriginPriceOld = entity.OriginPriceOld;

            ProductName = entity.Product.ProductName;
            Brand = new ProductBrandResponse(entity.Product.ProductBrand);
            Categories = entity.Product.ProductCategories.Select(x => new CategoryResponse(x.Category)).ToList();
        }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int PublicPrice { get; set; }

        public int OriginPrice { get; set; }

        public int SaleOffPrice { get; set; }
        public int OriginPriceOld { get; set; }

        public int SaleOffPriceOld { get; set; }

        public int GiaBanLe { get; set; }

        public ProductBrandResponse Brand { get; set; }

        public List<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

        public UserResponse UpdatedUser { get; set; }

        public new string CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }

    }

    public class DetailProductPriceLogResponse : ProductPriceLogResponse
    {
        public DetailProductPriceLogResponse()
        {

        }

        public DetailProductPriceLogResponse(ProductPriceLogEntity entity) : base(entity)
        {
            Product = new SimpleProductResponse(entity.Product);
            OriginPriceOld = entity.OriginPriceOld;
            SaleOffPriceOld = entity.SaleOffPriceOld;
        }
        public int OriginPriceOld { get; set; }

        public int SaleOffPriceOld { get; set; }
        public virtual SimpleProductResponse Product { get; set; }
    }
}
