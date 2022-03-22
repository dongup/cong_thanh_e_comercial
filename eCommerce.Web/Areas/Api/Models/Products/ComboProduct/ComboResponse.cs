using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities.Product.ComboProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.ComboProduct
{
    public class ComboResponse : BaseModel
    {
        public ComboResponse()
        {

        }

        public ComboResponse(ComboEntity entity) : base(entity)
        {
            if(entity != null)
            {
                Price = entity.Price;
                Name = entity.Name;
                Description = entity.Description;
                PromoContent = entity.PromoContent;
                GurantyTime = entity.GurantyTime;
                FriendlyUrl = entity.FriendlyUrl;
                ComboImages = entity.ComboImages.Select(x => new FileResponse(x.Image)).ToList();
                Products = entity.ComboProducts.Select(x => new SimpleProductResponse(x.Product)
                {
                    Quantity = x.Quantity
                }).ToList();
            }
        }

        public int Price { get; set; }

        public string Name { get; set; }
        public string PromoContent { get; set; }
        public string Description { get; set; }
        public string GurantyTime { get; set; }
        public string FriendlyUrl { get; set; }

        public ICollection<FileResponse> ComboImages  { get; set; }
        public ICollection<SimpleProductResponse> Products { get; set; }
    }
}
