using eCommerce.Web.Entities;
using Google.Apis.AnalyticsReporting.v4.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace eCommerce.Web.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin,Sale")]
    public class DashboardController : BaseController
    {
        public DashboardController(DatabaseContext context):base(context)  {  }

        public IActionResult Index()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(CallApiGoogleAnalytic(null, null, null));
        }

        [HttpPost]
        public IActionResult Index(string? startDate, string? endDate, string? metrics)
        {

            return Json(CallApiGoogleAnalytic(startDate, endDate, metrics));
        }

        public GetReportsResponse CallApiGoogleAnalytic(string? startDate, string? endDate, string? metrics)
        {
            var response = new Google.Apis.AnalyticsReporting.v4.Data.GetReportsResponse();
            var credential = Google.Apis.Auth.OAuth2.GoogleCredential.FromFile("serviceAccount.json")
            .CreateScoped(new[] { Google.Apis.AnalyticsReporting.v4.AnalyticsReportingService.Scope.AnalyticsReadonly });

            using (var analytics = new Google.Apis.AnalyticsReporting.v4.AnalyticsReportingService(new Google.Apis.Services.BaseClientService.Initializer
            {
                HttpClientInitializer = credential
            }))
            {
                var request = analytics.Reports.BatchGet(new GetReportsRequest
                {
                    ReportRequests = new[] {
                        new ReportRequest{
                            ViewId = "230262499",
                            DateRanges = new[] { new DateRange { StartDate = String.IsNullOrEmpty(startDate) == false ? startDate : "30daysAgo", EndDate = String.IsNullOrEmpty(endDate) == false ? endDate : "yesterday" } },
                            Metrics = new[] { new Metric{ Expression = String.IsNullOrEmpty(metrics) == false ? metrics : "ga:pageviews" } },
                            Dimensions = new[] { new Dimension{ Name = "ga:date" } },
                            Pivots = new[] {
                                new Pivot {
                                    Dimensions = new[] { new Dimension { Name = "ga:deviceCategory" } },
                                    Metrics = new[] { new Metric { Expression = String.IsNullOrEmpty(metrics) == false ? metrics : "ga:pageviews" } }
                                }
                            },
                        }
                }
                }
                );
                response = request.Execute();
            }
            return response;
        }
    }
}
