using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.User;
using eCommerce.Web.Entities.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using static eCommerce.Web.Entities.Product.ProductLogEntity;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class ProductLogResponse : BaseModel
    {
        public ProductLogResponse(ProductLogEntity entity) : base(entity)
        {
            Content = entity.Content;
            ProductId = entity.ProductId;
            Level = entity.Level;
            ProductName = entity.Product.ProductName;

            Brand = new ProductBrandResponse(entity.Product.ProductBrand);
            Categories = entity.Product.ProductCategories.Select(x => new CategoryResponse(x.Category)).ToList();
        }

        public int ProductId { get; set; }

        public string Content { get; set; }

        public string ProductName { get; set; }

        public ProductBrandResponse Brand { get; set; }

        public List<CategoryResponse> Categories { get; set; } = new List<CategoryResponse>();

        public UserResponse UpdatedUser { get; set; }

        public new string CreatedDate { get => base.CreatedDate; set => base.CreatedDate = value; }

        public LogLevel Level { get; set; }
    }

    public class DetailProductLogResponse : ProductLogResponse
    {
        public DetailProductLogResponse(ProductLogEntity entity) : base(entity)
        {
            Product = new SimpleProductResponse(entity.Product);
        }
    
        public SimpleProductResponse Product { get; set; }
    }
}
