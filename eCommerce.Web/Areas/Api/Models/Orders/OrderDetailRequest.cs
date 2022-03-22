using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Orders;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class OrderDetailRequest : BaseModel
    {
        public OrderDetailRequest()
        {

        }

        public OrderDetailEntity CopyTo(OrderDetailEntity entity)
        {
            base.CopyTo(entity);
            //entity.OrderId = OrderId;
            entity.ProductId = ProductId;
            entity.Quanity = Quantity;
            entity.BuyPrice = BuyPrice;

            return entity;
        }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; } = 1;

        public int BuyPrice { get; set; }

        public int OriginPrice { get; set; }

        public int SellOffPrice { get; set; }
    }
}
