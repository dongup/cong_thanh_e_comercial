using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Product
{
    public class ProductPriceLogEntity : BaseEntity
    {
        public ProductPriceLogEntity() : base()
        {

        }

        public int ProductId { get; set; }

        public int PublicPrice { get; set; }

        public int OriginPrice { get; set; }

        public int SaleOffPrice { get; set; }

        public int OriginPriceOld { get; set; }

        public int SaleOffPriceOld { get; set; }

        public int GiaBanLe { get; set; }

        public virtual ProductEntity Product { get; set; }
    }
}
