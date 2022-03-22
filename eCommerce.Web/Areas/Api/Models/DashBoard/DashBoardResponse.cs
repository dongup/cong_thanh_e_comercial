using eCommerce.Web.Areas.Api.Models.Products.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Api.Models.DashBoard
{
    public class DashBoardResponse
    {
        public int TotalOrder { get; set; }
        
        public int PendingOrder { get; set; }

        public int TotalProduct { get; set; }

        public int TotalPromotion { get; set; }
        public int CountDuplicateCode { get; set; }

        public List<OrderChartSeri> OrderChartData { get; set; }
        public List<ProductResponse> Products { get; set; }
    }

    public class OrderChartSeri
    {
        public int Count { get; set; }

        public string Date { get; set; }
    }
}
