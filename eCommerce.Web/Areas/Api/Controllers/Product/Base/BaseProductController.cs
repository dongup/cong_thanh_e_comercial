using eCommerce.Utils;
using eCommerce.Web.Areas.Api.Models.General;
using eCommerce.Web.Areas.Api.Models.Products.Product;
using eCommerce.Web.Entities;
using eCommerce.Web.Entities.Identity;
using eCommerce.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace eCommerce.Web.Areas.Api.Controllers.Product.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseProductController : BaseApiController
    {
        public enum ProductSortOrder
        {
            OriginPriceAsc = 1,
            OriginPriceDesc = 2,
            GiaBanLeAsc = 3,
            GiaBanLeDesc = 4,
            AccessCountAsc = 5,
            AccessCountDesc = 6

        }

        public BaseProductController(DatabaseContext context, 
            IConfiguration config = null, 
            IWebHostEnvironment webHost = null,
            UserManager<UserEntity> userManager = null) : base(context, config, webEnv: webHost, userManager: userManager)
        {

        }

        protected string GetProductImageSavePath(string productName)
        {
            return Path.Combine("Upload", "Products", productName);
        }

        protected Dictionary<string, string> GetParams(string urlStr)
        {
            Dictionary<string, string> dics = new Dictionary<string, string>();
            List<string> strings = urlStr.Split('&').ToList();
            foreach (var str in strings)
            {
                if (string.IsNullOrEmpty(str)) continue;
                string key = str.Split('=')[0].Trim().ToLower();
                string val = str.Split('=')[1].Trim().ToLower();

                dics.Add(key, val);
            }

            return dics;
        }

        protected List<FilterParamModel> GetFilterParams(Dictionary<string, string> data)
        {
            if (data == null) return null;
            List<FilterParamModel> filters = new List<FilterParamModel>();

            foreach (var item in data)
            {
                //Nếu key là số thì lấy giá trị
                if (int.TryParse(item.Key, out int propId))
                {
                    filters.Add(new FilterParamModel()
                    {
                        PropertyId = propId,
                        ValueIds = item.Value.Split(',').Select(delegate (string x) {
                            int.TryParse(x, out int a);
                            return a;
                        }).Where(x => x != 0).ToList(),
                    });
                }
            }

            return filters;
        }

        protected bool EntityExists(int id)
        {
            return _context.Products.Any(x => x.Id == id);
        }
    }

    public class FilterParamModel
    {
        public int PropertyId { get; set; }

        public List<int> ValueIds { get; set; }
    }
}
