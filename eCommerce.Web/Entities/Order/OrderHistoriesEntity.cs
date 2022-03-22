using eCommerce.Web.Entities.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Entities.Order
{
    public class OrderHistoriesEntity : BaseEntity
    {
        public int OrderId { get; set; }
        public string Content { get; set; }
        public int StatusOrder { get; set; }
        public  virtual OrderEntity Order { get; set; }
        public string CreatedUserName { get; set; }
    }
}
