using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Orders
{
    public class OrderDetailEntity : BaseEntity
    {
        public OrderDetailEntity() : base()
        {

        }

        public int? OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quanity { get; set; }

        public int BuyPrice { get; set; }

        public int OriginPrice { get; set; }

        public int SellOffPrice { get; set; }

        [ForeignKey(nameof(OrderId))]
        public virtual OrderEntity Order { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }
    }
}
