using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Products.Product
{
    public class ProductPriceRequest
    {
        public int PublicPrice { get; set; }

        public int OriginPrice { get; set; }

        public int SaleOffPrice { get; set; }

        public int GiaBanLe { get; set; } 
    }
}
