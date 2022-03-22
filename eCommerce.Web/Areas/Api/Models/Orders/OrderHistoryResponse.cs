using eCommerce.Web.Entities.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.Orders
{
    public class OrderHistoryResponse
    {
        public OrderHistoryResponse(OrderHistoriesEntity entity)
        {
            Content = entity.Content;
            Status = entity.StatusOrder;
            CreatedDate = entity.CreatedDate.ToString("HH:mm:ss dd/MM/yyyy");
            UserName = entity.CreatedUserName;
        }
        public string Content { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
        public string CreatedDate { get; set; }
    }
}
