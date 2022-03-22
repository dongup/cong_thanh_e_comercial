using eCommerce.Web.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Orders
{
    public class CartEntity : BaseEntity
    {
        public CartEntity() : base()
        {

        }

        public int CustomerId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public virtual UserEntity Customer { get; set; }

        [ForeignKey(nameof(ProductId))]
        public virtual ProductEntity Product { get; set; }
    }
}
