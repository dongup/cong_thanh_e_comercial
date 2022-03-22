using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.DashBoard;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using static eCommerce.Web.Entities.Orders.OrderEntity;

namespace eCommerce.Web.Areas.Api.Controllers
{
    [Route("api/[controller]")]

    [Authorize]
    public class DashBoardController : BaseApiController
    {
        public enum ChartType
        {
            ThisWeek = 1,
            ThisMonth = 2,
            ThisYear = 3
        }

        public DashBoardController(DatabaseContext context) : base(context)
        {

        }

        /// <summary>
        /// Lấy dữ liệu cho dashboard
        /// </summary>
        /// <param name="chartType">Loại biểu đồ 1: tuần này, 2: tháng này, 3: năm nay</param>
        /// <returns></returns>
        [HttpGet]
        public ResponseModel Order(int chartType)
        {
            try
            {
                DashBoardResponse data = new DashBoardResponse();
                data.TotalOrder = _context.Orders.Count();
                data.PendingOrder = _context.Orders.Where(x => x.Status == (int)OrderStatus.Pending).Count();
                data.TotalProduct = _context.Products.Count();
                data.TotalPromotion = _context.Promotions.Count();
                //var item = _context.Products.FromSqlRaw(@"SELECT ProductCode ,IsDeleted, COUNT(ProductCode) AS [Count]
                //                                            FROM dbo.Products
                //                                            GROUP BY ProductCode, IsDeleted
                //                                            HAVING COUNT(ProductCode)>1");
                var item = from o in _context.Products
                           group o by o.ProductCode into g
                           where g.Count() > 1
                           select new ProductResponse()
                           {
                               ProductCode = g.Key
                           };

                data.CountDuplicateCode = item == null ? 0 : item.Count();
                data.Products = item.ToList();


                switch ((ChartType)chartType)
                {
                    case ChartType.ThisWeek:
                        data.OrderChartData = GetDataThisWeek();
                        break;
                    case ChartType.ThisMonth:
                        data.OrderChartData = GetDataThisMonth();
                        break;
                    case ChartType.ThisYear:
                        data.OrderChartData = GetDataThisYear();
                        break;
                    default:
                        data.OrderChartData = GetDataThisWeek();
                        break;
                }

                res.Succeed(data);
            }
            catch (Exception ex)
            {
                res.Failed(ex.Message);
            }
            return res;
        }

        private List<OrderChartSeri> GetDataThisWeek()
        {
            List<OrderChartSeri> data = new List<OrderChartSeri>();
            DateTime fromDate = now.StartOfWeek();
            DateTime toDate = now;

            List<DateTime> dates = new List<DateTime>();
            for (DateTime date = fromDate; date.Date <= toDate; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            data = dates.Select(x => new OrderChartSeri()
            {
                Count = _context.Orders.Where(n => n.CreatedDate.Date == x.Date).Count(),
                Date = x.ToString("dddd", vnCulture)
            }).ToList();

            return data;
        }

        private List<OrderChartSeri> GetDataThisMonth()
        {
            List<OrderChartSeri> data = new List<OrderChartSeri>();
            DateTime fromDate = new DateTime(now.Year, now.Month, 1);
            DateTime toDate = now;

            List<DateTime> dates = new List<DateTime>();
            for (DateTime date = fromDate; date.Date <= toDate.Date; date = date.AddDays(1))
            {
                dates.Add(date);
            }

            data = dates.Select(x => new OrderChartSeri()
            {
                Count = _context.Orders.Where(n => n.CreatedDate.Date == x.Date).Count(),
                Date = x.ToString("dd/MM")
            }).ToList();

            return data;
        }

        private List<OrderChartSeri> GetDataThisYear()
        {
            List<OrderChartSeri> data = new List<OrderChartSeri>();
            DateTime fromDate = new DateTime(now.Year, 1, 1);
            DateTime toDate = now;

            List<DateTime> months = new List<DateTime>();
            for (DateTime date = fromDate; date.Date <= toDate.Date; date = date.AddMonths(1))
            {
                months.Add(date);
            }

            data = months.Select(x => new OrderChartSeri()
            {
                Count = _context.Orders.Where(n => n.CreatedDate.Month == x.Month).Count(),
                Date = x.ToString("MMMM", vnCulture)
            }).ToList();

            return data;
        }

    }
}
