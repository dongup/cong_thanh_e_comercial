using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Promotion;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace eCommerce.Web.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class GlobalDataMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration cf;
        public GlobalDataMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            cf = configuration;
        }

        public  Task Invoke(HttpContext httpContext, DatabaseContext context)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            InformationModel info = new InformationModel(context.Information.FirstOrDefault());
            var itemBannerAds = context.BannerAds.FirstOrDefault();
            BannerAdsResponse adverstire;
            if (itemBannerAds == null)
                adverstire = new BannerAdsResponse()
                {
                    IsShowLeft = false,
                    IsShowRight = false,
                    LeftFriendlyUrl = "#",
                    RighFriendlyUrl = "#",
                    LeftPath = "",
                    RightPath = "",
                    TopFriendlyUrl = "#",
                    IsShowTop = false,
                    TopPath = "",
                    BannerTopPromotionPath="",
                    BannerTopPromotionFriendlyUrl="#",
                    IsShowBannerTopPromotionPath=false,
                };
            else
                adverstire = new BannerAdsResponse()
                {
                    IsShowLeft = itemBannerAds.IsShowLeft,
                    IsShowRight = itemBannerAds.IsShowRight,
                    LeftFriendlyUrl = itemBannerAds.LeftFriendlyUrl,
                    RighFriendlyUrl = itemBannerAds.RighFriendlyUrl,
                    LeftPath = itemBannerAds.LeftPath,
                    RightPath = itemBannerAds.RightPath,
                    TopFriendlyUrl = itemBannerAds.TopFriendlyUrl,
                    IsShowTop = itemBannerAds.IsShowTop,
                    TopPath = itemBannerAds.TopPath,

                    PathBannerBottomSlide1 = itemBannerAds.PathBannerBottomSlide1,
                    PathBannerBottomSlide2 = itemBannerAds.PathBannerBottomSlide2,
                    PathBannerBottomSlide3 = itemBannerAds.PathBannerBottomSlide3,
                    UrlBannerBottomSlide1 = itemBannerAds.UrlBannerBottomSlide1,
                    UrlBannerBottomSlide2 = itemBannerAds.UrlBannerBottomSlide2,
                    UrlBannerBottomSlide3 = itemBannerAds.UrlBannerBottomSlide3,
                    IsShowBannerBottomSlide1 = itemBannerAds.IsShowBannerBottomSlide1,
                    IsShowBannerBottomSlide2 = itemBannerAds.IsShowBannerBottomSlide2,
                    IsShowBannerBottomSlide3 = itemBannerAds.IsShowBannerBottomSlide3,

                    IsShowBannerTopPromotionPath=itemBannerAds.IsShowBannerTopPromotionPath,
                    BannerTopPromotionFriendlyUrl=itemBannerAds.BannerTopPromotionFriendlyUrl,
                    BannerTopPromotionPath=itemBannerAds.BannerTopPromotionPath,

                };
            httpContext.Items["info"] = info;
            httpContext.Items["MiximumBuyInstallment"] = cf["MiximumBuyInstallment"]; ;
            httpContext.Items["bannerads"] = adverstire;
            var menus = cf
                    .GetSection("Menus")
                    .Get<Dictionary<string, string>[]>();
            httpContext.Items["Menus"] = menus;
            return _next(httpContext);
            watch.Stop();
            //if (watch.ElapsedMilliseconds > 100) { 
            //System.Console.WriteLine("//////////////////////////////////////////////");
            //System.Console.WriteLine("Time Exec: " + watch.ElapsedMilliseconds.ToString());
            //System.Console.WriteLine("APTH: " + httpContext.Request.Path.ToString());
            //System.Console.WriteLine("//////////////////////////////////////////////");
            //}

        }
    }
    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class GlobalDataMiddlewareExtensions
    {
        public static IApplicationBuilder UseGlobalDataMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<GlobalDataMiddleware>();
        }
    }
}

