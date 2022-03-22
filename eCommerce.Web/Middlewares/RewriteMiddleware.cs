using eCommerce.Utils;
using eCommerce.Web.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static eCommerce.Web.Entities.General.FriendlyUrlEntity;

namespace eCommerce.Web.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RewriteMiddleware
    {
        private readonly RequestDelegate _next;

        public RewriteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext, DatabaseContext context)
        {
            RewriteUrl(httpContext, context);
            return _next(httpContext);
        }

        public void RewriteUrl(HttpContext httpContext, DatabaseContext db)
        {
            var url = httpContext.Request.Path.ToString().Replace('/', ' ').Trim();

            //Không xử lý các request file
            if (url.Contains(".")) return;

            //Không xử lý các request api
            if (url.ToLower().Contains("api")) return;

            if (url == "gia-tot-hom-nay")
            {
                httpContext.Request.Path = $"/promo/{url}";
                return;
            }

            var urlObj = db.FriendlyUrls.FirstOrDefault(x => x.FriendlyUrl == url);

            if (urlObj == null) return;

            switch (urlObj.Type)
            {
                case UrlType.Post:
                    httpContext.Request.Path = $"/postdetail/{url}";
                    break;
                case UrlType.Product:
                    httpContext.Request.Path = $"/productdetail/{url}";
                    break;
                case UrlType.ProductCategory:
                    httpContext.Request.Path = $"/san-pham/{url}";
                    break;
                case UrlType.PostCategory:
                    httpContext.Request.Path = $"/bai-viet/{url}";
                    break;
                case UrlType.Promotion:
                    httpContext.Request.Path = $"/promo/{url}";
                    break;
                case UrlType.Group:
                    httpContext.Request.Path = $"/Group/{url}";
                    break;
                default:
                    break;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RewriteMiddlewareExtensions
    {
        public static IApplicationBuilder UseRewriteMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RewriteMiddleware>();
        }
    }
}
