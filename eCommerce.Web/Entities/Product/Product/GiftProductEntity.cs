using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities
{
    public class GiftProductEntity : BaseEntity
    {
        public GiftProductEntity() : base()
        {

        }

        public int ProductId { get; set; }

        public int GiftProductId { get; set; }

        public virtual ProductEntity Product { get; set; }
    }
}
