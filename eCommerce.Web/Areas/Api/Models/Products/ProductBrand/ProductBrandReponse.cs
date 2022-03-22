using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities;
using System.Collections.Generic;
using System.Linq;

namespace eCommerce.Web.Areas.Api.Models
{
    public class ProductBrandResponse : BaseModel
    {
        public ProductBrandResponse()
        {

        }

        public ProductBrandResponse(ProductBrandEntity entity) : base(entity)
        {
            if (entity == null) return;
            Id = entity.Id;
            LogoId = entity.LogoId;
            BrandName = entity.BrandName;
            Logo = new FileResponse(entity.Logo);
            CountProduct = (int)entity.Products?.Count();
            Categories = entity.BrandCategories?
                .Select(x => new CategoryResponse(x.ProductCategory))
                .ToList();
        }

        public int Order { get; set; }
        public int? LogoId { get; set; }

        public string BrandName { get; set; }

        public FileResponse Logo { get; set; }

        public int CountProduct { get; set; }

        public List<CategoryResponse> Categories { get; set; }

        //public ICollection<Product> Products { get; set; }
    }

}
