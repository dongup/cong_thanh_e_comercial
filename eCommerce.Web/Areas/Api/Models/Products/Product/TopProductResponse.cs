using eCommerce.Web.Areas.Api.Models.Products.Product;
using System.Collections.Generic;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class TopProductResponse 
    {
        public TopProductResponse()
        {

        }

        public int Count { get; set; } = 0;

        public List<ProductSimpleMostRespone> Products { get; set; } = new List<ProductSimpleMostRespone>();
    }

}
