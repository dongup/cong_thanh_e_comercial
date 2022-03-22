using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class OrderNotificationResponse : BaseModel
    {
        public OrderNotificationResponse(OrderNotificationEntity entity) : base(entity)
        {
            OrderId = entity.OrderId;
            Content = entity.Content;
            IsSeen = entity.IsSeen;
            Order = new OrderResponse(entity.Order);
        }

        public int OrderId { get; set; }

        public string Content { get; set; }

        public bool IsSeen { get; set; }

        public virtual OrderResponse Order { get; set; }
    }
}
