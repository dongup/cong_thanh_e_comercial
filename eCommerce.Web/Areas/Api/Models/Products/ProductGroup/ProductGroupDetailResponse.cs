using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.Promotion.PromotionEntity;

namespace eCommerce.Web.Areas.Api.Models.Products.ProductGroup
{
    public class ProductGroupDetailResponse : ProductGroupSimpleResponse
    {
        public List<ProductSimpleMostRespone> Products { get; set; }
    }
   }
