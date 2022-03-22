using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class OrderDetailResponse : BaseModel
    {
        public OrderDetailResponse()
        {

        }

        public OrderDetailResponse(OrderDetailEntity entity) : base(entity)
        {
            if (entity == null) return;

            OrderId = entity.OrderId;
            ProductId = entity.ProductId;
            Quanity = entity.Quanity;
            BuyPrice = entity.BuyPrice;
            OriginPrice = entity.OriginPrice;
            SellOffPrice = entity.SellOffPrice;

            Product = new SimpleProductResponse(entity.Product);
        }

        public int? OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quanity { get; set; } = 1;

        public int BuyPrice { get; set; }

        public int OriginPrice { get; set; }

        public int SellOffPrice { get; set; }

        public virtual SimpleProductResponse Product { get; set; }
    }
}
