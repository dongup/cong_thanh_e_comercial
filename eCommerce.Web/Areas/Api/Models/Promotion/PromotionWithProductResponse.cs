using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Promotion
{
    public class PromotionWithProductResponse
    {
        public PromotionResponse Promotion { get; set; }

        public PaginationResponse<ProductSimpleMostRespone> Products { get; set; }
    }
}
